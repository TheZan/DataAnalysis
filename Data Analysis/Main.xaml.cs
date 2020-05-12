using Data_Analysis.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialDesignThemes.Wpf;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using RDotNet;

namespace Data_Analysis
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DiscreteControl discreteControl = new DiscreteControl();
        IntervalControl intervalControl = new IntervalControl();

        public MainWindow()
        {
            InitializeComponent();
            gridMain.Children.Add(discreteControl);
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void changeTheme_Checked(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Dark);
            paletteHelper.SetTheme(theme);
            discreteControl.bgStart.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            intervalControl.bgStart2.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));
        }

        private void changeTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Light);
            paletteHelper.SetTheme(theme);
            discreteControl.bgStart.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            intervalControl.bgStart2.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            GridCursor.Margin = new Thickness((640 * index), 45, 0, 0);
            gridMain.Children.Clear();

            switch (index)
            {
                case 0:
                    gridMain.Children.Add(discreteControl);
                    break;
                case 1:
                    gridMain.Children.Add(intervalControl);
                    break;
            }
        }

        private void SaveDiscreteWord_Click(object sender, RoutedEventArgs e)
        {
            if (discreteControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Документ Word(*.docx)|*.docx";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                int columns = 3;
                int rows = discreteControl.DiscreteGrids.Count();
                double[] number = discreteControl.DiscreteGrids.Select(p => p.number).ToArray();
                double[] frequency = discreteControl.DiscreteGrids.Select(p => p.frequency).ToArray();
                int[] accumulatedFrequency = discreteControl.DiscreteGrids.Select(p => p.accumulatedFrequency).ToArray();
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Object missing = Type.Missing;
                application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Microsoft.Office.Interop.Word.Document document = application.ActiveDocument;
                Microsoft.Office.Interop.Word.Range range = application.Selection.Range;
                Object behiavor = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                Object autoFitBehiavor = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed;
                document.Tables.Add(range, rows + 1, columns, ref behiavor, ref autoFitBehiavor);
                document.Tables[1].Cell(1, 1).Range.Text = "Число";
                document.Tables[1].Cell(1, 2).Range.Text = "Частота";
                document.Tables[1].Cell(1, 3).Range.Text = "Накопленная частота";

                for (int i = 0; i < rows; i++)
                {
                    document.Tables[1].Cell(i + 2, 1).Range.Text = Convert.ToString(number[i]);
                    document.Tables[1].Cell(i + 2, 2).Range.Text = Convert.ToString(frequency[i]);
                    document.Tables[1].Cell(i + 2, 3).Range.Text = Convert.ToString(accumulatedFrequency[i]);
                }

                var Paragraph = application.ActiveDocument.Paragraphs.Add();
                var tableRange = Paragraph.Range;

                application.ActiveDocument.Tables.Add(tableRange, 15, 1);
                document.Tables[2].Cell(1, 1).Range.Text = "Расчеты";
                document.Tables[2].Cell(2, 1).Range.Text = discreteControl.tbAverageValue.Text;
                document.Tables[2].Cell(3, 1).Range.Text = discreteControl.tbMode.Text;
                document.Tables[2].Cell(4, 1).Range.Text = discreteControl.tbMedian.Text;
                document.Tables[2].Cell(5, 1).Range.Text = discreteControl.tbRangeOfVariation.Text;
                document.Tables[2].Cell(6, 1).Range.Text = discreteControl.tbMeanLinearDeviation.Text;
                document.Tables[2].Cell(7, 1).Range.Text = discreteControl.tbDispersion.Text;
                document.Tables[2].Cell(8, 1).Range.Text = discreteControl.tbStandardDeviation.Text;
                document.Tables[2].Cell(9, 1).Range.Text = discreteControl.tbCoefficientVariation.Text;
                document.Tables[2].Cell(10, 1).Range.Text = discreteControl.tbNormalCoefficientAsymmetry.Text;
                document.Tables[2].Cell(11, 1).Range.Text = discreteControl.tbEstimationCoefficientAsymmetry.Text;
                document.Tables[2].Cell(12, 1).Range.Text = discreteControl.tbDegreeAsymmetry.Text;
                document.Tables[2].Cell(13, 1).Range.Text = discreteControl.tbMaterialityAsymmetry.Text;
                document.Tables[2].Cell(14, 1).Range.Text = discreteControl.tbExcess.Text;
                document.Tables[2].Cell(15, 1).Range.Text = discreteControl.tbExcessError.Text;

                var table = application.ActiveDocument.Tables[application.ActiveDocument.Tables.Count];
                table.set_Style("Сетка таблицы");
                table.ApplyStyleHeadingRows = true;
                table.ApplyStyleLastRow = false;
                table.ApplyStyleFirstColumn = true;
                table.ApplyStyleLastColumn = false;
                table.ApplyStyleRowBands = true;
                table.ApplyStyleColumnBands = false;

                SaveToPng(discreteControl.polygon, "polygon.png");
                var endDocument = document.Paragraphs.Last.Range;
                string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "polygon.png");
                application.Selection.InlineShapes.AddPicture(path, Range: endDocument);
                File.Delete(path);
                application.ActiveDocument.SaveAs(FileName: filename);
                document.Close();
                application.Quit();
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveDiscreteExcel_Click(object sender, RoutedEventArgs e)
        {
            if (discreteControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Документ Excel(*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                int rows = discreteControl.DiscreteGrids.Count();
                double[] number = discreteControl.DiscreteGrids.Select(p => p.number).ToArray();
                double[] frequency = discreteControl.DiscreteGrids.Select(p => p.frequency).ToArray();
                int[] accumulatedFrequency = discreteControl.DiscreteGrids.Select(p => p.accumulatedFrequency).ToArray();
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                ExcelWorkSheet.Cells[1, 1] = "Число";
                ExcelWorkSheet.Cells[1, 2] = "Частота";
                ExcelWorkSheet.Cells[1, 3] = "Накопленная частота";
                ExcelWorkSheet.Cells[1, 4] = "Расчеты";
                ExcelWorkSheet.Cells[1, 1].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 2].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 3].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 4].Font.Bold = true;
                for (int i = 0; i < rows; i++)
                {
                    ExcelWorkSheet.Cells[i + 2, 1] = number[i];
                    ExcelWorkSheet.Cells[i + 2, 2] = frequency[i];
                    ExcelWorkSheet.Cells[i + 2, 3] = accumulatedFrequency[i];
                }

                ExcelWorkSheet.Cells[2, 4] = discreteControl.tbAverageValue.Text;
                ExcelWorkSheet.Cells[3, 4] = discreteControl.tbMode.Text;
                ExcelWorkSheet.Cells[4, 4] = discreteControl.tbMedian.Text;
                ExcelWorkSheet.Cells[5, 4] = discreteControl.tbRangeOfVariation.Text;
                ExcelWorkSheet.Cells[6, 4] = discreteControl.tbMeanLinearDeviation.Text;
                ExcelWorkSheet.Cells[7, 4] = discreteControl.tbDispersion.Text;
                ExcelWorkSheet.Cells[8, 4] = discreteControl.tbStandardDeviation.Text;
                ExcelWorkSheet.Cells[9, 4] = discreteControl.tbCoefficientVariation.Text;
                ExcelWorkSheet.Cells[10, 4] = discreteControl.tbNormalCoefficientAsymmetry.Text;
                ExcelWorkSheet.Cells[11, 4] = discreteControl.tbEstimationCoefficientAsymmetry.Text;
                ExcelWorkSheet.Cells[12, 4] = discreteControl.tbDegreeAsymmetry.Text;
                ExcelWorkSheet.Cells[13, 4] = discreteControl.tbMaterialityAsymmetry.Text;
                ExcelWorkSheet.Cells[14, 4] = discreteControl.tbExcess.Text;
                ExcelWorkSheet.Cells[15, 4] = discreteControl.tbExcessError.Text;

                ExcelWorkSheet.Columns.AutoFit();

                ExcelWorkBook.SaveAs(filename);
                ExcelWorkBook.Close();
                ExcelApp.Quit();
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName)) encoder.Save(stream);
        }

        private void SaveIntervalWord_Click(object sender, RoutedEventArgs e)
        {
            if (intervalControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Документ Word(*.docx)|*.docx";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                int columns = 4;
                int rows = intervalControl.IntervalGrid.Count();
                double[] lBorder = intervalControl.IntervalGrid.Select(p => p.leftBorder).ToArray();
                double[] rBorder = intervalControl.IntervalGrid.Select(p => p.rightBorder).ToArray();
                double[] frequency = intervalControl.IntervalGrid.Select(p => p.frequency).ToArray();
                double[] accumulatedFrequency = intervalControl.IntervalGrid.Select(p => p.accumulatedFrequency).ToArray();
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Object missing = Type.Missing;
                application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Microsoft.Office.Interop.Word.Document document = application.ActiveDocument;
                Microsoft.Office.Interop.Word.Range range = application.Selection.Range;
                Object behiavor = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                Object autoFitBehiavor = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed;
                document.Tables.Add(range, rows + 1, columns, ref behiavor, ref autoFitBehiavor);
                document.Tables[1].Cell(1, 1).Range.Text = "Левая граница";
                document.Tables[1].Cell(1, 2).Range.Text = "Правая граница";
                document.Tables[1].Cell(1, 3).Range.Text = "Частота";
                document.Tables[1].Cell(1, 4).Range.Text = "Накопленная частота";
                for (int i = 0; i < rows; i++)
                {
                    document.Tables[1].Cell(i + 2, 1).Range.Text = Convert.ToString(lBorder[i]);
                    document.Tables[1].Cell(i + 2, 2).Range.Text = Convert.ToString(rBorder[i]);
                    document.Tables[1].Cell(i + 2, 3).Range.Text = Convert.ToString(frequency[i]);
                    document.Tables[1].Cell(i + 2, 4).Range.Text = Convert.ToString(accumulatedFrequency[i]);
                }

                var Paragraph = application.ActiveDocument.Paragraphs.Add();
                var tableRange = Paragraph.Range;

                application.ActiveDocument.Tables.Add(tableRange, 15, 1);
                document.Tables[2].Cell(1, 1).Range.Text = "Расчеты";
                document.Tables[2].Cell(2, 1).Range.Text = intervalControl.tbAverageValue.Text;
                document.Tables[2].Cell(3, 1).Range.Text = intervalControl.tbMode.Text;
                document.Tables[2].Cell(4, 1).Range.Text = intervalControl.tbMedian.Text;
                document.Tables[2].Cell(5, 1).Range.Text = intervalControl.tbRangeOfVariation.Text;
                document.Tables[2].Cell(6, 1).Range.Text = intervalControl.tbMeanLinearDeviation.Text;
                document.Tables[2].Cell(7, 1).Range.Text = intervalControl.tbDispersion.Text;
                document.Tables[2].Cell(8, 1).Range.Text = intervalControl.tbStandardDeviation.Text;
                document.Tables[2].Cell(9, 1).Range.Text = intervalControl.tbCoefficientVariation.Text;
                document.Tables[2].Cell(10, 1).Range.Text = intervalControl.tbNormalCoefficientAsymmetry.Text;
                document.Tables[2].Cell(11, 1).Range.Text = intervalControl.tbEstimationCoefficientAsymmetry.Text;
                document.Tables[2].Cell(12, 1).Range.Text = intervalControl.tbDegreeAsymmetry.Text;
                document.Tables[2].Cell(13, 1).Range.Text = intervalControl.tbMaterialityAsymmetry.Text;
                document.Tables[2].Cell(14, 1).Range.Text = intervalControl.tbExcess.Text;
                document.Tables[2].Cell(15, 1).Range.Text = intervalControl.tbExcessError.Text;

                var table = application.ActiveDocument.Tables[application.ActiveDocument.Tables.Count];
                table.set_Style("Сетка таблицы");
                table.ApplyStyleHeadingRows = true;
                table.ApplyStyleLastRow = false;
                table.ApplyStyleFirstColumn = true;
                table.ApplyStyleLastColumn = false;
                table.ApplyStyleRowBands = true;
                table.ApplyStyleColumnBands = false;

                SaveToPng(intervalControl.barChart, "barChart.png");
                var endDocument = document.Paragraphs.Last.Range;
                string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "barChart.png");
                application.Selection.InlineShapes.AddPicture(path, Range: endDocument);
                File.Delete(path);
                application.ActiveDocument.SaveAs(FileName: filename);
                document.Close();
                application.Quit();
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveIntervalExcel_Click(object sender, RoutedEventArgs e)
        {
            if (intervalControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Документ Excel(*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                int rows = intervalControl.IntervalGrid.Count();
                double[] lBorder = intervalControl.IntervalGrid.Select(p => p.leftBorder).ToArray();
                double[] rBorder = intervalControl.IntervalGrid.Select(p => p.rightBorder).ToArray();
                double[] frequency = intervalControl.IntervalGrid.Select(p => p.frequency).ToArray();
                double[] accumulatedFrequency = intervalControl.IntervalGrid.Select(p => p.accumulatedFrequency).ToArray();
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                ExcelWorkSheet.Cells[1, 1] = "Левая граница";
                ExcelWorkSheet.Cells[1, 2] = "Правая граница";
                ExcelWorkSheet.Cells[1, 3] = "Частота";
                ExcelWorkSheet.Cells[1, 4] = "Накопленная частота";
                ExcelWorkSheet.Cells[1, 5] = "Расчеты";
                ExcelWorkSheet.Cells[1, 1].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 2].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 3].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 4].Font.Bold = true;
                ExcelWorkSheet.Cells[1, 5].Font.Bold = true;
                for (int i = 0; i < rows; i++)
                {
                    ExcelWorkSheet.Cells[i + 2, 1] = lBorder[i];
                    ExcelWorkSheet.Cells[i + 2, 2] = rBorder[i];
                    ExcelWorkSheet.Cells[i + 2, 3] = frequency[i];
                    ExcelWorkSheet.Cells[i + 2, 4] = accumulatedFrequency[i];
                }

                ExcelWorkSheet.Cells[2, 5] = intervalControl.tbAverageValue.Text;
                ExcelWorkSheet.Cells[3, 5] = intervalControl.tbMode.Text;
                ExcelWorkSheet.Cells[4, 5] = intervalControl.tbMedian.Text;
                ExcelWorkSheet.Cells[5, 5] = intervalControl.tbRangeOfVariation.Text;
                ExcelWorkSheet.Cells[6, 5] = intervalControl.tbMeanLinearDeviation.Text;
                ExcelWorkSheet.Cells[7, 5] = intervalControl.tbDispersion.Text;
                ExcelWorkSheet.Cells[8, 5] = intervalControl.tbStandardDeviation.Text;
                ExcelWorkSheet.Cells[9, 5] = intervalControl.tbCoefficientVariation.Text;
                ExcelWorkSheet.Cells[10, 5] = intervalControl.tbNormalCoefficientAsymmetry.Text;
                ExcelWorkSheet.Cells[11, 5] = intervalControl.tbEstimationCoefficientAsymmetry.Text;
                ExcelWorkSheet.Cells[12, 5] = intervalControl.tbDegreeAsymmetry.Text;
                ExcelWorkSheet.Cells[13, 5] = intervalControl.tbMaterialityAsymmetry.Text;
                ExcelWorkSheet.Cells[14, 5] = intervalControl.tbExcess.Text;
                ExcelWorkSheet.Cells[15, 5] = intervalControl.tbExcessError.Text;

                ExcelWorkSheet.Columns.AutoFit();

                ExcelWorkBook.SaveAs(filename);
                ExcelWorkBook.Close();
                ExcelApp.Quit();
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveDiscretePDF_Click(object sender, RoutedEventArgs e)
        {
            if (discreteControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Файл PDF|*.pdf";
                sfd.DefaultExt = "pdf";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter writer = PdfWriter.GetInstance(document,
                 new FileStream(sfd.FileName, FileMode.Create)
                 );

                document.Open();

                string fg = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.TTF");
                BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("Первичный статистический анализ данных. Дискретный ряд.", fgFont);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                iTextSharp.text.Paragraph p_1 = new iTextSharp.text.Paragraph(" ", fgFont);
                document.Add(p_1);

                int column = 3;
                int row = discreteControl.DiscreteGrids.Count();

                PdfPTable table = new PdfPTable(column);

                PdfPCell cell1 = new PdfPCell(new Phrase(new Phrase("Номер", fgFont)));
                cell1.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase(new Phrase("Частота", fgFont)));
                cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Phrase(new Phrase("Накопленная частота", fgFont)));
                cell3.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell3);

                double[] number = discreteControl.DiscreteGrids.Select(c => c.number).ToArray();
                double[] frequency = discreteControl.DiscreteGrids.Select(c => c.frequency).ToArray();
                int[] accumulatedFrequency = discreteControl.DiscreteGrids.Select(c => c.accumulatedFrequency).ToArray();

                for (int i = 0; i < row; i++)
                {
                    string num = "", fre = "", acc = "";
                    num = number[i].ToString();
                    fre = frequency[i].ToString();
                    acc = accumulatedFrequency[i].ToString();

                    table.AddCell(new Phrase(num));
                    table.AddCell(new Phrase(fre));
                    table.AddCell(new Phrase(acc));
                }
                document.Add(table);

                iTextSharp.text.Paragraph p_2 = new iTextSharp.text.Paragraph(" ", fgFont);
                document.Add(p_2);

                PdfPTable table2 = new PdfPTable(1);
                PdfPCell cell = new PdfPCell(new Phrase(new Phrase("Расчеты", fgFont)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table2.AddCell(cell);
                table2.AddCell(new Phrase(discreteControl.tbAverageValue.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbMode.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbMedian.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbRangeOfVariation.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbMeanLinearDeviation.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbDispersion.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbStandardDeviation.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbCoefficientVariation.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbNormalCoefficientAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbEstimationCoefficientAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbDegreeAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbMaterialityAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbExcess.Text, fgFont));
                table2.AddCell(new Phrase(discreteControl.tbExcessError.Text, fgFont));
                document.Add(table2);

                document.NewPage();
                iTextSharp.text.Paragraph p_4 = new iTextSharp.text.Paragraph("Полигон", fgFont);
                p_4.Alignment = Element.ALIGN_CENTER;
                document.Add(p_4);

                SaveToPng(discreteControl.polygon, "polygon.png");
                string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "polygon.png");
                iTextSharp.text.Image chart_image = iTextSharp.text.Image.GetInstance(path);
                chart_image.Alignment = Element.ALIGN_CENTER;
                chart_image.ScaleToFit(344f, 336f);
                document.Add(chart_image);
                File.Delete(path);
                document.Close();
                writer.Close();
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveIntervalPDF_Click(object sender, RoutedEventArgs e)
        {
            if (intervalControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Файл PDF|*.pdf";
                sfd.DefaultExt = "pdf";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter writer = PdfWriter.GetInstance(document,
                 new FileStream(sfd.FileName, FileMode.Create)
                 );

                document.Open();

                string fg = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.TTF");
                BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("Первичный статистический анализ данных. Интервальный ряд.", fgFont);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                iTextSharp.text.Paragraph p_1 = new iTextSharp.text.Paragraph(" ", fgFont);
                document.Add(p_1);

                int column = 4;
                int row = intervalControl.IntervalGrid.Count();

                PdfPTable table = new PdfPTable(column);

                PdfPCell cell1 = new PdfPCell(new Phrase(new Phrase("Левая граница", fgFont)));
                cell1.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase(new Phrase("Правая граница", fgFont)));
                cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Phrase(new Phrase("Частота", fgFont)));
                cell3.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Phrase(new Phrase("Накопленная частота", fgFont)));
                cell4.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell4);

                double[] lBorder = intervalControl.IntervalGrid.Select(c => c.leftBorder).ToArray();
                double[] rBorder = intervalControl.IntervalGrid.Select(c => c.rightBorder).ToArray();
                double[] frequency = intervalControl.IntervalGrid.Select(c => c.frequency).ToArray();
                double[] accumulatedFrequency = intervalControl.IntervalGrid.Select(c => c.accumulatedFrequency).ToArray();

                for (int i = 0; i < row; i++)
                {
                    string lb = "", rb = "", fre = "", acc = "";
                    lb = lBorder[i].ToString();
                    rb = rBorder[i].ToString();
                    fre = frequency[i].ToString();
                    acc = accumulatedFrequency[i].ToString();

                    table.AddCell(new Phrase(lb));
                    table.AddCell(new Phrase(rb));
                    table.AddCell(new Phrase(fre));
                    table.AddCell(new Phrase(acc));
                }
                document.Add(table);

                iTextSharp.text.Paragraph p_2 = new iTextSharp.text.Paragraph(" ", fgFont);
                document.Add(p_2);

                PdfPTable table2 = new PdfPTable(1);
                PdfPCell cell = new PdfPCell(new Phrase(new Phrase("Расчеты", fgFont)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table2.AddCell(cell);
                table2.AddCell(new Phrase(intervalControl.tbAverageValue.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbMode.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbMedian.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbRangeOfVariation.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbMeanLinearDeviation.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbDispersion.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbStandardDeviation.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbCoefficientVariation.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbNormalCoefficientAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbEstimationCoefficientAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbDegreeAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbMaterialityAsymmetry.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbExcess.Text, fgFont));
                table2.AddCell(new Phrase(intervalControl.tbExcessError.Text, fgFont));
                document.Add(table2);

                document.NewPage();
                iTextSharp.text.Paragraph p_4 = new iTextSharp.text.Paragraph("Гистограмма", fgFont);
                p_4.Alignment = Element.ALIGN_CENTER;
                document.Add(p_4);

                SaveToPng(intervalControl.barChart, "barChart.png");
                string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "barChart.png");
                iTextSharp.text.Image chart_image = iTextSharp.text.Image.GetInstance(path);
                chart_image.Alignment = Element.ALIGN_CENTER;
                chart_image.ScaleToFit(344f, 336f);
                document.Add(chart_image);
                File.Delete(path);
                document.Close();
                writer.Close();
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveDiscreteXML_Click(object sender, RoutedEventArgs e)
        {
            if (discreteControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Файл Xml|*.xml";
                sfd.DefaultExt = "xml";

                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                int column = 3, row = discreteControl.DiscreteGrids.Count();
                double[] number = discreteControl.DiscreteGrids.Select(c => c.number).ToArray();
                double[] frequency = discreteControl.DiscreteGrids.Select(c => c.frequency).ToArray();
                int[] accumulatedFrequency = discreteControl.DiscreteGrids.Select(c => c.accumulatedFrequency).ToArray();

                XDocument xdoc = new XDocument();
                XElement InputData = new XElement("InputData");
                XAttribute col1 = new XAttribute("Number", "Номер");
                InputData.Add(col1);
                XAttribute col2 = new XAttribute("Frequency", "Частота");
                InputData.Add(col2);
                XAttribute col3 = new XAttribute("AccumulatedFrequency", "Накопленная частота");
                InputData.Add(col3);
                for (int i = 0; i < row; i++)
                {
                    XElement dataRowElement = new XElement("Row");

                    for (int j = 0; j < column; j++)
                    {
                        string num = "", fre = "", acc = "";
                        num = number[i].ToString();
                        fre = frequency[i].ToString();
                        acc = accumulatedFrequency[i].ToString();

                        XElement dataColumnElement1 = new XElement("Number", num);
                        XElement dataColumnElement2 = new XElement("Frequency", fre);
                        XElement dataColumnElement3 = new XElement("AccumulatedFrequency", acc);
                        dataRowElement.Add(dataColumnElement1);
                        dataRowElement.Add(dataColumnElement2);
                        dataRowElement.Add(dataColumnElement3);
                    }

                    InputData.Add(dataRowElement);
                }

                XElement analysis = new XElement("DataAnalysis");
                analysis.Add(InputData);
                xdoc.Add(analysis);
                xdoc.Save(sfd.FileName);
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void SaveIntervalXML_Click(object sender, RoutedEventArgs e)
        {
            if (intervalControl.Open)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Файл Xml|*.xml";
                sfd.DefaultExt = "xml";

                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                int column = 4, row = intervalControl.IntervalGrid.Count();
                double[] lBorder = intervalControl.IntervalGrid.Select(c => c.leftBorder).ToArray();
                double[] rBorder = intervalControl.IntervalGrid.Select(c => c.rightBorder).ToArray();
                double[] frequency = intervalControl.IntervalGrid.Select(c => c.frequency).ToArray();
                double[] accumulatedFrequency = intervalControl.IntervalGrid.Select(c => c.accumulatedFrequency).ToArray();

                XDocument xdoc = new XDocument();
                XElement InputData = new XElement("InputData");
                XAttribute col1 = new XAttribute("LeftBorder", "Левая граница");
                InputData.Add(col1);
                XAttribute col2 = new XAttribute("RightBorder", "Правая граница");
                InputData.Add(col2);
                XAttribute col3 = new XAttribute("Frequency", "Частота");
                InputData.Add(col3);
                XAttribute col4 = new XAttribute("AccumulatedFrequency", "Накопленная частота");
                InputData.Add(col4);

                for (int i = 0; i < row; i++)
                {
                    XElement dataRowElement = new XElement("Row");

                    for (int j = 0; j < column; j++)
                    {
                        string lb = "", rb = "", fre = "", acc = "";
                        lb = lBorder[i].ToString();
                        rb = rBorder[i].ToString();
                        fre = frequency[i].ToString();
                        acc = accumulatedFrequency[i].ToString();

                        XElement dataColumnElement1 = new XElement("LeftBorder", lb);
                        XElement dataColumnElement2 = new XElement("RightBorder", rb);
                        XElement dataColumnElement3 = new XElement("Frequency", fre);
                        XElement dataColumnElement4 = new XElement("AccumulatedFrequency", acc);
                        dataRowElement.Add(dataColumnElement1);
                        dataRowElement.Add(dataColumnElement2);
                        dataRowElement.Add(dataColumnElement3);
                    }

                    InputData.Add(dataRowElement);
                }

                XElement analysis = new XElement("DataAnalysis");
                analysis.Add(InputData);
                xdoc.Add(analysis);
                xdoc.Save(sfd.FileName);
            }
            else
            {
                dialogError.IsOpen = true;
            }
        }

        private void btOkay_Click(object sender, RoutedEventArgs e)
        {
            dialogError.IsOpen = false;
        }

        private void btOkayTeam_Click(object sender, RoutedEventArgs e)
        {
            dialogTeam.IsOpen = false;
        }

        private void teamAbout_Click(object sender, RoutedEventArgs e)
        {
            dialogTeam.IsOpen = true;
        }
    }
}
