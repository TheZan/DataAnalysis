   M S B A M L   `   `   `  ���� H  DData Analysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Data_AnalysisData_Analysis  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf     Data_Analysis.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Data_Analysis     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     MaterialDesignBody#���     MaterialDesignPaper#���  $��Medium"�$��14(�  � Title$O  IПервичный статистический анализ данных�� � 
ResizeMode$ NoResize=�$	��720��$
��1280�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=���:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .���  � RowDefinitions �� $��30 ��� $��50 ��� .+�� $��0�� � ColumnDefinitions �� �� $��50 ��� $��50 �.+��� -   $��3��$��0��
��� ���o� 
���   �
��� ��� o� 
IsMainMenu . $��5q�$	��180��$
��Left=�.@�m� $��Меню��$��20�� m� Icon 0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ChartBar=�.@�m� $��Сохранить как��.@�m� $!��Дискретный ряд��.@�m� -   	 m�Name$	 SaveDiscreteWord��$
��Word��   $ FileWordOutline=�m� -   $	 SaveDiscreteExcel��$��Excel��   $ FileExcelOutline=�m� -   $	 SaveDiscretePDF��$	��PDF��   $ FilePdfOutline=�m� -   $	 SaveDiscreteXML��$	��XML��   $	 Xml=�m� $%��Интервальный ряд��.@�m� -   $	 SaveIntervalWord��$
��Word��   $ FileWordOutline=�m� -   $	 SaveIntervalExcel��$��Excel��   $ FileExcelOutline=�m� -   $	 SaveIntervalPDF��$	��PDF��   $ FilePdfOutline=�m� -	   $	 SaveIntervalXML��$	��XML��   $	 Xml=�m� -
   $��Система R��m� $��О программе��.@�m� -   $	 	teamAbout��$#��Команда проекта���� �� 
 �� Orientation$
 
Horizontal=�.+��� $��Тема��d� -    d�Name$ changeTheme��$��
5, 0, 0, 0q� $  MaterialDesignSwitchToggleButton#��[ �� -    ��Name$ btClose��
������ 
������ $��2��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=��� -   $ 
btMinimize��
������ 
������ $��1��.��  $ WindowMinimize=�� $��1��.+��� $
 
Horizontal=�$	��Top=�.+��� -   
 J� Uid$ 0��$	��640��$!��Дискретный ряд��$��50��
��� �����Z� ��Z� �� -   $ 1��$	��640��$%��Интервальный ряд��$��50��
��� �����Z� ��Z� � -    �Name$ 
GridCursor��$	��640��$��5��
��� ���$
��Left=�$��0,45,0,0q�� -   $ gridMain��$��2��)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ dialogError��   IsOpen .     
Identifier$ errorDialog��$��3��   DialogContent � $��20q�.+��� .+��� -    ��Name$ tbError��$��5q�$��Center=�$��Center=�$6��0Нет данных для сохранения!���� $��Center=�$
 
Horizontal=�.+��� -   $ btOkay��$��5q�$
��Ок��  -   $ 
dialogTeam�� .  $ errorDialog��$��3�� � $��20q�.+��� .+��� -   $ tbTeam��$��5q�$��Center=�$��Center=�$#��Команда проекта��  $��50��$��50��$��Center=�$��Center=�$ About=��� -   $ tbTeam1��$��5q�$��Center=�$��Center=�$0��*Разработчик: Сочнев М.В���� -   $ tbTeam2��$��5q�$��Center=�$��Center=�$2��,Руководитель: Нуждин Р.С���� -   $ tbTeam3��$��5q�$��Center=�$��Center=�$E��?Технический писатель: Соловьев В.С���� $��Center=�$
 
Horizontal=�.+��� -   $ 
btOkayTeam��$��5q�$
��Ок��