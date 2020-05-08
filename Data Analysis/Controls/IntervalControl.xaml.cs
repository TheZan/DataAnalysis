using Data_Analysis.Class;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RDotNet;

namespace Data_Analysis.Controls
{
    /// <summary>
    /// Логика взаимодействия для IntervalControl.xaml
    /// </summary>
    public partial class IntervalControl : UserControl
    {
        IntervalRow intervalRow;
        public List<IntervalGrid> IntervalGrid = new List<IntervalGrid>();
        public string[] Labels { get; set; }
        public bool Open = false;
        public IntervalControl()
        {
            InitializeComponent();
        }

        private double[] x;
        private double[] y;

        private void BuildChart()
        {
            barChart.DataContext = null;
            y = IntervalGrid.Select(p => p.frequency).ToArray();
            x = IntervalGrid.Select(p => p.leftBorder).ToArray();
            Labels = new string[x.Length];
            barChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double>(y)
                }
            };

            for (int i = 0; i < x.Length; i++)
            {
                Labels[i] = x[i].ToString();
            }

            barChart.DataContext = this;
        }

        private void Calculate()
        {
            tbAverageValue.Text = "Средняя величина: " + intervalRow.CalculateAverageValue();
            tbMode.Text = "Мода: " + intervalRow.CalculateMode();
            tbMedian.Text = "Медиана: " + intervalRow.CalculateMedia();
            tbRangeOfVariation.Text = "Размах вариации: " + intervalRow.CalculateRangeOfVariation(); ;
            tbMeanLinearDeviation.Text = "Среднее линейное отклонение: " + intervalRow.CalculateMeanLinearDeviation();
            tbDispersion.Text = "Дисперсия: " + intervalRow.CalculateDispersion();
            tbStandardDeviation.Text = "Среднее квадратичное отклонение: " + intervalRow.CalculateStandardDeviation();
            tbCoefficientVariation.Text = "Коэффициент вариации: " + intervalRow.CalculateCoefficientVariation();
            tbNormalCoefficientAsymmetry.Text = "Нормированный моментный коэффициент асимметрии: " + intervalRow.CalculateNormalCoefficientAsymmetry();
            tbEstimationCoefficientAsymmetry.Text = "Оценка коэффициента асимметрии: " + intervalRow.EstimationCoefficientAsymmetry;
            tbDegreeAsymmetry.Text = "Степень существенности асимметрии: " + intervalRow.CalculateDegreeAsymmetry();
            tbMaterialityAsymmetry.Text = "Оценка существенности асимметрии: " + intervalRow.MaterialityAsymmetry;
            tbExcess.Text = "Эксцесс: " + intervalRow.CalculateExcess();
            tbExcessError.Text = "Средняя квадратическая ошибка эксцесса: " + intervalRow.CalculateExcessError();
        }

        private void btYes_Click(object sender, RoutedEventArgs e)
        {
            intervalRow = new IntervalRow();
            intervalRow.LoadFromCSV();
            string flName = intervalRow.FLName;
            int error = intervalRow.Error;
            if (flName != "")
            {
                if (error == 0)
                {
                    discreteGrid.Visibility = Visibility.Visible;
                    calculated.Visibility = Visibility.Visible;
                    bgStart2.Visibility = Visibility.Collapsed;
                    IntervalGrid = intervalRow.FillDataGridTwo();
                    discreteGrid.ItemsSource = IntervalGrid;
                    Calculate();
                    BuildChart();
                }
                else
                {
                    dialogError.IsOpen = true;
                    tbError.Text = "В " + error + " ячейке(ах) есть ошибки";
                }
            }
            dialogReInit.IsOpen = false;
        }

        private void btNo_Click(object sender, RoutedEventArgs e)
        {
            dialogReInit.IsOpen = false;
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (Open)
            {
                dialogReInit.IsOpen = true;
            }
            else
            {
                intervalRow = new IntervalRow();
                intervalRow.LoadFromCSV();
                string flName = intervalRow.FLName;
                int error = intervalRow.Error;
                if (flName != "")
                {
                    if (error == 0)
                    {
                        discreteGrid.Visibility = Visibility.Visible;
                        calculated.Visibility = Visibility.Visible;
                        bgStart2.Visibility = Visibility.Collapsed;
                        IntervalGrid = intervalRow.FillDataGridTwo();
                        btR.Visibility = Visibility.Visible;
                        discreteGrid.ItemsSource = IntervalGrid;
                        Calculate();
                        BuildChart();
                        Open = true;
                    }
                    else
                    {
                        dialogReInit.IsOpen = false;
                        dialogError.IsOpen = true;
                        tbError.Text = "В " + error + " ячейке(ах) есть ошибки";
                    }
                }
            }
        }

        private void btOkay_Click(object sender, RoutedEventArgs e)
        {
            dialogError.IsOpen = false;
        }

        private void BtR_OnClick(object sender, RoutedEventArgs e)
        {
            if (Open)
            {
                try
                {
                    REngine.SetEnvironmentVariables();
                    REngine engine = REngine.GetInstance();
                    engine.Initialize();
                    engine.SetSymbol("x", engine.CreateNumericVector(x));
                    engine.SetSymbol("y", engine.CreateNumericVector(y));
                    engine.Evaluate("plot(x, y, type = 'h', main = 'Интервальный вариационный ряд')");
                }
                catch
                {
                    MessageBox.Show("RGUI.exe не найден!", "Ошибка");
                }
            }
        }
    }
}
