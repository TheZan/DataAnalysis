   M S B A M L   `   `   `  ����H  DData Analysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Data_Analysis.ControlsData_Analysis.Controls  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      ,    &Data_Analysis.Controls.IntervalControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Data_Analysis.Controls     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	         MaterialDesignBody#���   5
        MaterialDesignPaper#���  5      $��Medium"�5      $��14(�5      ��5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �   � ColumnDefinitions  5   
   �� 5      $
��293* �6   �� 5      $
��988* �6    � RowDefinitions 5   
   �� 5      6   �� 5      $��58 �6   6*   .+�5   
   � $��0��6   $��2��6     5      �� 5      $
��349* �6#   62   �� 5      $	��377 �6#   62   �� 5      $	��430 �6#   61   .+�5      �� $#��Исходные данные��6   $��0��60   $��5,10,5,5q�6@   .��5       &   System.Windows.Controls.DataGrid  -   5          Name$ discreteGrid��5    �      
IsReadOnly .    CanUserDeleteRows .  $y�	Collapsed=�6G      CanUserAddRows .  $��10(�6u      AutoGenerateColumns .  $��0��6�   $��3q�6�      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Левая граница��6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6-   �� 
 �� Path$
 
leftBorder�6l     5#      $! Правая граница��6T   	 6-   �� $
 rightBorder�6n     5$      $ Частота��6R   	 6-   �� $
 	frequency�6e     5%         Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6]   $+ %Накопленная частота��6i   	 6-   �� $
 accumulatedFrequency�   HeaderStyle 5&      �� 5'   "    �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6(    & "MaterialDesignDataGridColumnHeader �� BasedOn# [ 6S   .�5(   &   ��  �� Property � �� �� Value$ Right=�6L   �� 5)   &    � �� 5*   *   �� 5+   .   .R�5,   2   �� $
��Wrap=�6<    �� TextAlignment$ Right=�6a   ��6P   �� 6a   5-   /   5/   '   50   #   52      54      55      �� 56      $��5,10,5,5q�6   $��Расчеты��6)   $��1��6:   .��57      �� -   5         ��Name$ 
calculated��57      $y�	Collapsed=�61   .+�58      �� -   5         ��Name$ tbAverageValue��58   4   $
��Wrap=�6    6N   �� 59      �� 5:      -   5        $ tbMode��5:   4   $
��Wrap=�6    6F   �� 5;      �� 5<      -   5        $ tbMedian��5<   4   $
��Wrap=�6    6H   �� 5=      �� 5>      -   5        $ tbRangeOfVariation��5>   4   $
��Wrap=�6    6R   �� 5?      �� 5@      -   5        $ tbMeanLinearDeviation��5@   4   $
��Wrap=�6    6U   �� 5A      �� 5B      -   5        $ tbDispersion��5B   4   $
��Wrap=�6    6L   �� 5C      �� 5D      -	   5        $ tbStandardDeviation��5D   4   $
��Wrap=�6    6S   �� 5E      �� 5F      -
   5        $ tbCoefficientVariation��5F   4   $
��Wrap=�6    6V   �� 5G      �� 5H      -   5        $" tbNormalCoefficientAsymmetry��5H   4   $
��Wrap=�6    6\   �� 5I      �� 5J      -   5        $&  tbEstimationCoefficientAsymmetry��5J   4   $
��Wrap=�6    6`   �� 5K      �� 5L      -   5        $ tbDegreeAsymmetry��5L   4   $
��Wrap=�6    6Q   �� 5M      �� 5N      -   5        $ tbMaterialityAsymmetry��5N   4   $
��Wrap=�6    6V   �� 5O      �� 5P      -   5        $ tbExcess��5P   4   $
��Wrap=�6    6H   �� 5Q      �� 5R      -   5        $ tbExcessError��5R   4   $
��Wrap=�6    6M   �� 5S      5T      5U      �� 5V      $��2��6   $��5q�6'   $��Гистограмма��62   .��5W      #  LiveCharts.Wpf.CartesianChart  -   5          Name$ barChart��5W   :   $y�Visible=�6%   $��2��6L   $��5q�6�   &	   LiveCharts.Wpf.Charts.Base.Chart 	  Series 6\   �� *BarChartCollection+ 	  AxisY 5Y      
  LiveCharts.Wpf.Axis
   
  Title$ Y��6#    
  LabelFormatter 6-   �� *
YFormatter+6U    	  AxisX 5\      
  $ X��6#    
  Labels 6-   �� *Labels+6I   5^      5_      5`      �� 5a   
   -   5         ��Name$ btCalculate��5a   ,   $��1��6A   $ ��Выбрать файл...��6N   $��264.5,16,573,0q�6h   $	��Top=�6�   $��1��6�   �� 5b   
   -   5        $	 btR��5b   >   $y�	Collapsed=�6&   $��1��6K   $��Открыть R��6X   $��Center=�6l   $��Right=�6�   $��10q�6�   $��1��6�   )  #MaterialDesignThemes.Wpf.DialogHost  5c   
   -   5          Name$ dialogReInit��5c   3      IsOpen .     
Identifier$ reInit��6I   $��2��6]      DialogContent 5d      � 5e      $��20q�6   .+�5f      �� .+�5g      �� $��5q�6$   $��Center=�6/   $��Center=�6J   $y��sВсе несохраненные данные будут потеряны. Вы хотите продолжить?��6g   �� 5h      $��Center=�6%     �� Orientation$  
Horizontal=�6B   .+�5i      �� -   5        $ btYes��5i   :   $��5q�6I   $
��Да��6T   6c   �� 5j      -   5        $
 btNo��5j   9   $��5q�6G   $��Нет��6R   6b   5k      5l      5m      5o      �� 5p   
   -   5        $ bgStart2��5p   =   $y�Visible=�6   
�������$��2��6O   .+�5q      �� $��10q�6   $��70(�6$   $	��Top=�62   $��Center=�6J   $��Начало работы��6g   �� 5r      $��10q�6   $����1. Для начала работы нажмите на кнопку 'Выбрать файл...' и выберите нужный Вам файл в формате csv.��6$   $��20(�6�   6�   �� 5s      $��10q�6   $u��o2. После этого вы сможете увидеть результат работы программы.��6$   $��20(�6i   6y   �� 5t      $��10q�6   $����3. Далее Вы сможете сохранить результаты в любом из предложенных форматов, а также взаимодействовать с системой R.��6$   $��20(�6�   6�   5u        5v   
   -   5        $ dialogError��5v   3    .  $ errorDialog��6H   $��2��6a   $��
-10,0,10,0q�6u    5w      � 5x      $��20q�6   .+�5y      �� .+�5z      �� -   5        $ tbError��5z   $   $��5q�65   $��Center=�6@   $��Center=�6[   �� 5{      $��Center=�6%   $  
Horizontal=�6B   .+�5|      �� -   5        $ btOkay��5|   ;   $��5q�6K   $
��Ок��6V   6e   5}      5~      5      5�      5�      5�      