using Data_Analysis.Class;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Data_Analysis.Controls
{
    /// <summary>
    /// Логика взаимодействия для DiscreteControl.xaml
    /// </summary>
    public partial class DiscreteControl : UserControl
    {
        DiscreteRow discreteRow;
        public List<DiscreteGrid> DiscreteGrids = new List<DiscreteGrid>();
        public SeriesCollection SeriesCollection { get; set; }
        public bool Open = false;

        public DiscreteControl()
        {
            InitializeComponent();
        }

        private void Calculate()
        {
            tbAverageValue.Text = "Средняя величина: " + discreteRow.CalculateAverageValue();
            tbMode.Text = "Мода: " + discreteRow.CalculateMode();
            tbMedian.Text = "Медиана: " + discreteRow.CalculateMedia();
            tbRangeOfVariation.Text = "Размах вариации: " + discreteRow.CalculateRangeOfVariation(); ;
            tbMeanLinearDeviation.Text = "Среднее линейное отклонение: " + discreteRow.CalculateMeanLinearDeviation();
            tbDispersion.Text = "Дисперсия: " + discreteRow.CalculateDispersion();
            tbStandardDeviation.Text = "Среднее квадратичное отклонение: " + discreteRow.CalculateStandardDeviation();
            tbCoefficientVariation.Text = "Коэффициент вариации: " + discreteRow.CalculateCoefficientVariation();
            tbNormalCoefficientAsymmetry.Text = "Нормированный моментный коэффициент асимметрии: " + discreteRow.CalculateNormalCoefficientAsymmetry();
            tbEstimationCoefficientAsymmetry.Text = "Оценка коэффициента асимметрии: " + discreteRow.EstimationCoefficientAsymmetry;
            tbDegreeAsymmetry.Text = "Степень существенности асимметрии: " + discreteRow.CalculateDegreeAsymmetry();
            tbMaterialityAsymmetry.Text = "Оценка существенности асимметрии: " + discreteRow.MaterialityAsymmetry;
            tbExcess.Text = "Эксцесс: " + discreteRow.CalculateExcess();
            tbExcessError.Text = "Средняя квадратическая ошибка эксцесса: " + discreteRow.CalculateExcessError();
        }

        private void BuildChart()
        {
            polygon.DataContext = null;
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>(),
                }
            };
            double[] x = DiscreteGrids.Select(p => p.number).ToArray();
            int[] y = DiscreteGrids.Select(p => p.frequency).ToArray();
            foreach (var series in SeriesCollection)
            {
                for (var i = 0; i < x.Length; i++)
                {
                    series.Values.Add(new ObservablePoint(x[i], y[i]));
                }
            }

            polygon.DataContext = this;
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (Open)
            {
                dialogReInit.IsOpen = true;
            }
            else
            {
                discreteRow = new DiscreteRow();
                discreteRow.LoadFromCSV();
                string flName = discreteRow.FLName;
                int error = discreteRow.Error;
                if (flName != "")
                {
                    if (error == 0)
                    {
                        DiscreteGrids = discreteRow.FillDataGrid();
                        discreteGrid.Visibility = Visibility.Visible;
                        polygon.Visibility = Visibility.Visible;
                        calculated.Visibility = Visibility.Visible;
                        bgStart.Visibility = Visibility.Collapsed;
                        discreteGrid.ItemsSource = DiscreteGrids;
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

        private void btYes_Click(object sender, RoutedEventArgs e)
        {
            discreteRow = new DiscreteRow();
            discreteRow.LoadFromCSV();
            string flName = discreteRow.FLName;
            int error = discreteRow.Error;
            if (flName != "")
            {
                if (error == 0)
                {
                    DiscreteGrids = discreteRow.FillDataGrid();
                    discreteGrid.Visibility = Visibility.Visible;
                    polygon.Visibility = Visibility.Visible;
                    calculated.Visibility = Visibility.Visible;
                    bgStart.Visibility = Visibility.Collapsed;
                    discreteGrid.ItemsSource = DiscreteGrids;
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
            dialogReInit.IsOpen = false;
        }

        private void btNo_Click(object sender, RoutedEventArgs e)
        {
            dialogReInit.IsOpen = false;
        }

        private void btOkay_Click(object sender, RoutedEventArgs e)
        {
            dialogError.IsOpen = false;
        }
    }
}
