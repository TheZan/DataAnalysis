   M S B A M L   `   `   `  ����H  DData Analysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Data_AnalysisData_Analysis  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       Data_Analysis.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Data_Analysis     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	     � Title$O  IПервичный статистический анализ данных��5   	    � 
ResizeMode$ NoResize=�68   $	��720��6N   $
��1280��6[    � WindowStartupLocation$ CenterScreen=�6h    � WindowStyle$
 None=�6�   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      6%   �� 5      $��50 �6#   60   �� 5      $��50 �6#   60   .+�5      �� -   5        $��3��5      $��0��6`   
��� ���6}   o� 5      
���   �
��� ��� o� 
IsMainMenu . $��5q�6L   $	��180��6W   $
��Left=�6c   .@�5      m� $��Меню��6J   $��20��6X    m� Icon 6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ChartBar=�.@�5      m� $��Сохранить как��6   .@�5       m� $!��Дискретный ряд��6#   .@�5!      m� -   5        	 m�Name$	 SaveDiscreteWord��5!   k   $
��Word��6]    6'     $ FileWordOutline=�6�   m� 5"      -   5        $	 SaveDiscreteExcel��5"   m   $��Excel��6^    6'     $ FileExcelOutline=�6�   m� 5#      -   5        $	 SaveDiscretePDF��5#   i   $	��PDF��6\    6'     $ FilePdfOutline=�6�   m� 5$      -   5        $	 SaveDiscreteXML��5$   ^   $	��XML��6Q    6'     $	 Xml=�6�   5%      m� 5&      $%��Интервальный ряд��6#   .@�5'      m� -   5        $	 SaveIntervalWord��5'   k   $
��Word��6]    6'     $ FileWordOutline=�6�   m� 5(      -   5        $	 SaveIntervalExcel��5(   m   $��Excel��6^    6'     $ FileExcelOutline=�6�   m� 5)      -   5        $	 SaveIntervalPDF��5)   i   $	��PDF��6\    6'     $ FilePdfOutline=�6�   m� 5*      -	   5        $	 SaveIntervalXML��5*   ^   $	��XML��6Q    6'     $	 Xml=�6�   5+      5,      m� 5-      $��О программе��6   .@�5.      m� -
   5        $	 	teamAbout��5.   <   $#��Команда проекта��6#   6i   5/      �� 50      6"   �� 51      
 �� Orientation$
 
Horizontal=�6!   .+�52      �� $��Тема��6$   62   d� 53      -   5         d�Name$ changeTheme��53   {   $��
5, 0, 0, 0q�6I    $  MaterialDesignSwitchToggleButton#��[ 6�   54      55      56      �� 57      -   5         ��Name$ btClose��57   n   
������ 
������ $��2��6^   .��58      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6*   69   59      �� 5:      -   5        $ 
btMinimize��5:   q   
������ 
������ $��1��6a   .��5;        $ WindowMinimize=�6*   6B   5<      5=      � 5>   
   $��1��6   .+�5?      �� $
 
Horizontal=�6   $	��Top=�62   .+�5@      �� -   5        
 J� Uid$ 0��5@      $	��640��6   $!��Дискретный ряд��6)   $��50��6B   
��� �����6N   Z� ��6d   Z� 6�   �� 5A      -   5        $ 1��5A      $	��640��6   $%��Интервальный ряд��6)   $��50��6D   
��� �����6P   Z� ��6f   Z� 6�   5B      � 5C      -   5         �Name$ 
GridCursor��5C      $	��640��6'   $��5��63   
��� ���$
��Left=�6R   $��0,45,0,0q�6m   5D      � 5E   
   -   5        $ gridMain��5E      $��2��6!   5F      )  #MaterialDesignThemes.Wpf.DialogHost  5G   
   -   5          Name$ dialogError��5G   3      IsOpen .     
Identifier$ errorDialog��6H   $��3��6a      DialogContent 5H      � 5I      $��20q�6   .+�5J      �� .+�5K      �� -   5         ��Name$ tbError��5K   $   $��5q�65   $��Center=�6@   $��Center=�6[   $6��0Нет данных для сохранения!��6x   �� 5L      $��Center=�6%   $
 
Horizontal=�6B   .+�5M      �� -   5        $ btOkay��5M   ;   $��5q�6K   $
��Ок��6V   6e   5N      5O      5P      5R        5S   
   -   5        $ 
dialogTeam��5S   3    .  $ errorDialog��6G   $��3��6`    5T      � 5U      $��20q�6   .+�5V      �� .+�5W      �� -   5        $ tbTeam��5W   $   $��5q�64   $��Center=�6?   $��Center=�6Z   $#��Команда проекта��6w     5X      $��50��62   $��50��6=   $��Center=�6I   $��Center=�6f   $ About=�6�   6�   �� 5Y      -   5        $ tbTeam1��5Y   $   $��5q�65   $��Center=�6@   $��Center=�6[   $0��*Разработчик: Сочнев М.В��6x   �� 5Z      -   5        $ tbTeam2��5Z   $   $��5q�65   $��Center=�6@   $��Center=�6[   $2��,Руководитель: Нуждин Р.С��6x   �� 5[      -   5        $ tbTeam3��5[   $   $��5q�65   $��Center=�6@   $��Center=�6[   $E��?Технический писатель: Соловьев В.С��6x   �� 5\      $��Center=�6%   $
 
Horizontal=�6B   .+�5]      �� -   5        $ 
btOkayTeam��5]   ?   $��5q�6S   $
��Ок��6^   6m   5^      5_      5`      5b      5c      5d      