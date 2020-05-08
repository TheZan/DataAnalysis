using Data_Analysis.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Data_Analysis
{
    class IntervalRow
    {
        List<string> RowList = new List<string>();
        public List<IntervalGrid> IntervalGrid = new List<IntervalGrid>();

        int[] m;
        int GroupCount = 0;
        public int Error = 0;

        public string EstimationCoefficientAsymmetry = "",
            MaterialityAsymmetry = "",
            ExcessErrorString = "",
            FLName = "";
        double Dispersion = 0,
            StandardDeviation = 0,
            CoefficientVariation = 0,
            NormalCoefficientAsymmetry = 0,
            Excess = 0,
            H = 0,
            Xmin = 0,
            Xmax = 0,
            AverageValue = 0;

        /*Метод для заполнения данными из CSV файла списка RowList*/
        public List<string> LoadFromCSV()
        {
            Error = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV файл (*.csv)|*.csv";
            ofd.FileName = "";
            ofd.Title = "Открыть";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string str;
                using (var R = new StreamReader(ofd.FileName))
                {
                    FLName = ofd.FileName;
                    while ((str = R.ReadLine()) != null)
                    {
                        String[] array = str.Split(new char[] { ';' });
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] != "")
                            {
                                try
                                {
                                    Convert.ToDouble(array[i]);
                                    RowList.Add(array[i]);

                                }
                                catch
                                {
                                    Error++;
                                }

                            }
                        }
                    }
                    if (Error != 0)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < RowList.Count; i++)
                        {
                            for (int j = 0; j < RowList.Count - 1; j++)
                            {
                                if (Convert.ToDouble(RowList[j]) > Convert.ToDouble(RowList[j + 1]))
                                {
                                    string t = RowList[j];
                                    (RowList[j]) = (RowList[j + 1]);
                                    RowList[j + 1] = t;
                                }
                            }
                        }
                        /*Поиск максимального и минимального значений*/
                        Xmax = Convert.ToDouble(RowList[0]); Xmin = Convert.ToDouble(RowList[0]);
                        for (int i = 0; i < RowList.Count; i++)
                        {
                            if (Xmax < Convert.ToDouble(RowList[i]))
                            {
                                Xmax = Convert.ToDouble(RowList[i]);
                            }
                            if (Xmin > Convert.ToDouble(RowList[i]))
                            {
                                Xmin = Convert.ToDouble(RowList[i]);
                            }
                        }

                        GroupCount = Convert.ToInt32(1 + 3.332 * Math.Log10(RowList.Count));
                        H = (Xmax - Xmin) / GroupCount;
                        m = new int[GroupCount];
                        for (int i = 0; i < RowList.Count; i++)
                        {
                            for (int j = 0; j < m.Length; j++)
                            {
                                double t = Xmin + j * H;
                                if (Convert.ToDouble(RowList[i]) >= t && Convert.ToDouble(RowList[i]) < t + H)
                                {
                                    m[j]++;
                                }
                            }
                            if (Convert.ToDouble(RowList[i]) == Xmax)
                            {
                                m[m.Length - 1]++;
                            }
                        }
                    }
                }
            }
            return RowList;
        }

        /*Метод для заполнения списка IntervalGrid, для дальнейшего заполнения DataGrid в IntervalControl*/
        public List<IntervalGrid> FillDataGridTwo()
        {
            try
            {
                double M = 0;

                for (int i = 0; i < m.Length; i++)
                {
                    M += m[i];
                    IntervalGrid.Add(new IntervalGrid { leftBorder = Xmin + i * H, rightBorder = Xmin + i * H + H, frequency = m[i], accumulatedFrequency = M });
                }
                return IntervalGrid;
            }
            catch
            {
                return IntervalGrid;
            }
        }

        /*Метод для поиска средней величины*/
        public double CalculateAverageValue()
        {
            try
            {
                AverageValue = 0;
                double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
                double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
                double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
                for (int i = 0; i < IntervalGrid.Count - 1; i++)
                {
                    AverageValue += (Convert.ToDouble(lBorder[i]) + (((Convert.ToDouble(rBorder[i])) - (Convert.ToDouble(lBorder[i]))) / 2)) * Convert.ToDouble(freq[i]);
                }
                AverageValue = AverageValue / RowList.Count;
                return Math.Round(AverageValue, 2);
            }
            catch
            {
                return Math.Round(AverageValue, 2);
            }
        }

        /*Метод для поиска моды*/
        public double CalculateMode()
        {
            double frequency = 0;
            double Mode = 0;
            try
            {
                double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
                double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
                double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
                for (int i = 1; i < IntervalGrid.Count; i++)
                {
                    if (frequency < freq[i])
                    {
                        frequency = Convert.ToDouble(freq[i]);
                        Mode = lBorder[i] + (H * (Convert.ToDouble((freq[i] - freq[i - 1])) / (Convert.ToDouble((freq[i] - freq[i - 1])) + (Convert.ToDouble(freq[i] - freq[i + 1])))));
                    }
                }
                return Math.Round(Mode, 2);
            }
            catch
            {
                return Math.Round(Mode, 2);
            }
        }

        /*Метод для поиска медианы*/
        public double CalculateMedia()
        {
            double Median = 0;
            double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
            double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
            double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
            double[] accumFreq = IntervalGrid.Select(p => p.accumulatedFrequency).ToArray();
            try
            {
                int N = RowList.Count / 2;
                for (int i = 1; i < IntervalGrid.Count - 1; i++)
                {
                    if ((RowList.Count % 2) == 0)
                    {
                        if ((Convert.ToDouble(lBorder[i])) <= (RowList.Count / 2) && (RowList.Count / 2) >= (Convert.ToDouble(rBorder[i])))
                        {
                            Median = (Convert.ToDouble(lBorder[i])) + (H * ((RowList.Count / 2) - (Convert.ToDouble(accumFreq[i - 1]))) / (Convert.ToDouble(freq[i])));
                        }
                        else break;
                    }
                    else break;

                    if ((RowList.Count + 1) % 2 == 0)
                    {
                        if ((Convert.ToDouble(lBorder[i])) <= (RowList.Count / 2) && (RowList.Count / 2) >= (Convert.ToDouble(rBorder[i])))
                        {
                            Median = (Convert.ToDouble(lBorder[i])) + (H * ((RowList.Count / 2) - (Convert.ToDouble(accumFreq[i - 1]))) / (Convert.ToDouble(freq[i])));
                        }
                        else break;
                    }
                    else break;
                }
                return Math.Round(Median, 2);
            }
            catch
            {
                return Math.Round(Median, 2);
            }
        }

        /*Метод для поиска размаха вариации*/
        public double CalculateRangeOfVariation()
        {
            double RangeOfVariation = 0;
            try
            {
                Double Xmax = Convert.ToDouble(RowList[0]), Xmin = Convert.ToDouble(RowList[0]);
                for (int i = 0; i < RowList.Count; i++)
                {
                    if (Xmax < Convert.ToDouble(RowList[i]))
                    {
                        Xmax = Convert.ToDouble(RowList[i]);
                    }
                    if (Xmin > Convert.ToDouble(RowList[i]))
                    {
                        Xmin = Convert.ToDouble(RowList[i]);
                    }
                }
                RangeOfVariation = Xmax - Xmin;
                return Math.Round(RangeOfVariation, 2);
            }
            catch
            {
                return Math.Round(RangeOfVariation, 2);
            }
        }

        /*Метод для поиска среднего линейного отклонения*/
        public double CalculateMeanLinearDeviation()
        {
            double MeanLinearDeviation = 0;
            double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
            double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
            double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
            try
            {
                for (int i = 1; i < IntervalGrid.Count - 1; i++)
                {
                    MeanLinearDeviation += (Math.Abs((((Convert.ToDouble(lBorder[i])) + ((Convert.ToDouble(rBorder[i])) - (Convert.ToDouble(lBorder[i])))) / 2) / AverageValue) * (Convert.ToDouble(freq[i]))) / RowList.Count;
                }
                return Math.Round(MeanLinearDeviation, 2);
            }
            catch
            {
                return Math.Round(MeanLinearDeviation, 2);
            }
        }

        /*Метод для поиска дисперсии*/
        public double CalculateDispersion()
        {
            double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
            double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
            double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
            try
            {
                Dispersion = 0;
                for (int i = 1; i < IntervalGrid.Count - 1; i++)
                {
                    Dispersion += ((Math.Pow(((((Convert.ToDouble(lBorder[i])) + ((Convert.ToDouble(rBorder[i])) - (Convert.ToDouble(lBorder[i])))) / 2) / AverageValue), 2)) * (Convert.ToDouble(freq[i]))) / RowList.Count;
                }
                return Math.Round(Dispersion, 2);
            }
            catch
            {
                return Math.Round(Dispersion, 2);
            }
        }

        /*Метод для поиска среднего квадратичного отклонения*/
        public double CalculateStandardDeviation()
        {
            try
            {
                StandardDeviation = 0;
                StandardDeviation = Math.Sqrt(Dispersion);
                return Math.Round(StandardDeviation, 2);
            }
            catch
            {
                return Math.Round(StandardDeviation, 2);
            }
        }

        /*Метод для поиска коэффициента вариации*/
        public double CalculateCoefficientVariation()
        {
            try
            {
                CoefficientVariation = 0;
                CoefficientVariation = (StandardDeviation / AverageValue) / 100;
                return Math.Round(CoefficientVariation, 2);
            }
            catch
            {
                return Math.Round(CoefficientVariation, 2);
            }
        }

        /*Метод для поиска нормированного моментного коэффициента асимметрии и его оценки*/
        public double CalculateNormalCoefficientAsymmetry()
        {
            double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
            double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
            double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
            try
            {
                EstimationCoefficientAsymmetry = "";
                NormalCoefficientAsymmetry = 0;
                double Mom = 0;
                for (int i = 1; i < IntervalGrid.Count - 1; i++)
                {
                    Mom += Math.Abs(((Math.Pow(((((Convert.ToDouble(lBorder[i])) + ((Convert.ToDouble(rBorder[i])) - (Convert.ToDouble(lBorder[i])))) / 2) / AverageValue), 3))) * (Convert.ToDouble(freq[i]))) / RowList.Count;
                }
                NormalCoefficientAsymmetry = Mom / (Math.Pow(StandardDeviation, 3));
                if (NormalCoefficientAsymmetry == 0)
                {
                    EstimationCoefficientAsymmetry = "Ряд симметричен";
                }
                else if (NormalCoefficientAsymmetry > 0)
                {
                    EstimationCoefficientAsymmetry = "Правосторонняя скошенность ряда";
                }
                else
                {
                    EstimationCoefficientAsymmetry = "Левосторонняя скошенность ряда";
                }
                return Math.Round(NormalCoefficientAsymmetry, 2);
            }
            catch
            {
                return Math.Round(NormalCoefficientAsymmetry, 2);
            }
        }

        /*Метод для поиска степени существенности асимметрии*/
        public double CalculateDegreeAsymmetry()
        {
            MaterialityAsymmetry = "";
            double DegreeAsymmetry = 0;
            try
            {
                DegreeAsymmetry = Math.Sqrt((6 * ((RowList.Count - 1) - 1)) / ((RowList.Count - 1) + 1) * ((RowList.Count - 1) + 3));
                if (((Math.Abs(NormalCoefficientAsymmetry) / DegreeAsymmetry)) > 3)
                {
                    MaterialityAsymmetry = "Существенная асимметрия";
                }
                else
                {
                    MaterialityAsymmetry = "Несущественная асимметрия";
                }
                return Math.Round(DegreeAsymmetry, 2);
            }
            catch
            {
                return Math.Round(DegreeAsymmetry, 2);
            }
        }

        /*Метод для поиска эксцесса*/
        public double CalculateExcess()
        {
            double[] lBorder = IntervalGrid.Select(p => p.leftBorder).ToArray();
            double[] rBorder = IntervalGrid.Select(p => p.rightBorder).ToArray();
            double[] freq = IntervalGrid.Select(p => p.frequency).ToArray();
            try
            {
                Excess = 0;
                double mom = 0;
                for (int i = 1; i < IntervalGrid.Count - 1; i++)
                {
                    mom = ((Math.Pow(((((Convert.ToDouble(lBorder[i])) + ((Convert.ToDouble(rBorder[i])) - (Convert.ToDouble(lBorder[i])))) / 2) / AverageValue), 4)) * (Convert.ToDouble(freq[i]))) / RowList.Count;
                }
                Excess = mom / (Math.Pow(StandardDeviation, 4) - 3);
                return Math.Round(Excess, 2);
            }
            catch
            {
                return Math.Round(Excess, 2);
            }
        }

        /*Метод для поиска ошибки эксцесса*/
        public string CalculateExcessError()
        {
            ExcessErrorString = "";
            double ExcessError = 0;
            try
            {
                ExcessError = Math.Sqrt(((24 * RowList.Count) * (RowList.Count - 2) * (RowList.Count - 3)) / ((Math.Pow((RowList.Count - 1), 2)) * (RowList.Count + 3) * (RowList.Count + 5)));
                if ((Math.Abs(Excess) / ExcessError) > 3)
                {
                    ExcessErrorString = "Отклонение существенно";
                }
                else
                {
                    ExcessErrorString = "Отклонение несущественно";
                }
                return ExcessErrorString;
            }
            catch
            {
                return ExcessErrorString;
            }
        }
    }
}
