   M S B A M L   `   `   `  ���� H  DData Analysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Data_Analysis.ControlsData_Analysis.Controls  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf ,    &Data_Analysis.Controls.IntervalControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Data_Analysis.Controls     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     MaterialDesignBody#���     MaterialDesignPaper#���  $��Medium"�$��14(���:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .���   � ColumnDefinitions  �� $
��293* ��� $
��988* � � RowDefinitions �� �� $��58 �.+�� $��0��$��2��  �� $
��349* ��� $	��377 ��� $	��430 �.+��� $#��Исходные данные��$��0��$��5,10,5,5q�.��&   System.Windows.Controls.DataGrid  -     Name$ discreteGrid��   
IsReadOnly .    CanUserDeleteRows .  $y�	Collapsed=�   CanUserAddRows .  $��10(�   AutoGenerateColumns .  $��0��$��3q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Левая граница��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� 
 �� Path$
 
leftBorder�  $! Правая граница��	 �� $
 rightBorder�  $ Частота��	 �� $
 	frequency�     Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 $+ %Накопленная частота��	 �� $
 accumulatedFrequency�   HeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"   & "MaterialDesignDataGridColumnHeader �� BasedOn# [ .���  �� Property � �� �� Value$ Right=���  � �� �� .R��� $
��Wrap=� �� TextAlignment$ Right=����� �� $��5,10,5,5q�$��Расчеты��$��1��.���� -    ��Name$ 
calculated��$y�	Collapsed=�.+��� -    ��Name$ tbAverageValue��$
��Wrap=��� �� -   $ tbMode��$
��Wrap=��� �� -   $ tbMedian��$
��Wrap=��� �� -   $ tbRangeOfVariation��$
��Wrap=��� �� -   $ tbMeanLinearDeviation��$
��Wrap=��� �� -   $ tbDispersion��$
��Wrap=��� �� -	   $ tbStandardDeviation��$
��Wrap=��� �� -
   $ tbCoefficientVariation��$
��Wrap=��� �� -   $" tbNormalCoefficientAsymmetry��$
��Wrap=��� �� -   $&  tbEstimationCoefficientAsymmetry��$
��Wrap=��� �� -   $ tbDegreeAsymmetry��$
��Wrap=��� �� -   $ tbMaterialityAsymmetry��$
��Wrap=��� �� -   $ tbExcess��$
��Wrap=��� �� -   $ tbExcessError��$
��Wrap=��� �� $��2��$��5q�$��Гистограмма��.��#  LiveCharts.Wpf.CartesianChart  -     Name$ barChart��$y�Visible=�$��2��$��5q�&	   LiveCharts.Wpf.Charts.Base.Chart 	  Series �� *BarChartCollection+ 	  AxisY 
  LiveCharts.Wpf.Axis
   
  Title$ Y�� 
  LabelFormatter �� *
YFormatter+ 	  AxisX 
  $ X�� 
  Labels �� *Labels+�� -    ��Name$ btCalculate��$��1��$ ��Выбрать файл...��$��264.5,16,573,0q�$	��Top=�$��1��)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ dialogReInit��   IsOpen .     
Identifier$ reInit��$��2��   DialogContent � $��20q�.+��� .+��� $��5q�$��Center=�$��Center=�$y��sВсе несохраненные данные будут потеряны. Вы хотите продолжить?���� $��Center=�  �� Orientation$  
Horizontal=�.+��� -   $ btYes��$��5q�$
��Да���� -   $
 btNo��$��5q�$��Нет���� -   $ bgStart2��$y�Visible=�
�������$��2��.+��� $��0, 250, 0, 0q�$��70(�$��Center=�$��Center=�$A��;Для начала работы выберите файл!��  -   $ dialogError�� .  $ errorDialog��$��2��$��
-10,0,10,0q� � $��20q�.+��� .+��� -   $ tbError��$��5q�$��Center=�$��Center=��� $��Center=�$  
Horizontal=�.+��� -   $ btOkay��$��5q�$
��Ок��