   M S B A M L   `   `   `  ����E  ANakayamaPJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:NakayamaPJ.ViewNakayamaPJ.View  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          NakayamaPJ.View.HomeView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:NakayamaPJ.View     5      K
LiveCharts4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   $��0��6:   .+�5      (  "System.Windows.Controls.DatePicker  $��10,0,0,0q�6   �� 5      $��Ok��6   $��10,0,0,0q�6"   �� 5      $��Custom��6   $��10,0,0,0q�6&   �� 5      $��Today��6   $��10,0,0,0q�6%   �� 5      $��Last 7 Days��6   $��10,0,0,0q�6+   �� 5      $��Last 30 Days��6   $��10,0,0,0q�6,   �� 5      $��
This Month��6   $��10,0,0,0q�6*   5      � 5   
   $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��2* �6#   .+�5#      �   5$      �� 5%      $
��Auto �6$   �� 5&      $��* �6$   �� 5'      $
��Auto �6$   .+�5+      �� $ 
Horizontal=�6   $��Center=�66   $��0,0,0,20q�6S   .+�5,      �� $��10q�6!   $��Center=�6-   .+�5-      �� $��Number of Orders��6$   $
��Bold"�6<   �� 5.      $��100000��6$   $��16(�62   �� 5/      $
��+15%��6$   
��� � �60   50      �� 51      $��10q�6!   .+�52      �� $��Total Revenue��6$   $
��Bold"�69   �� 53      $��100000��6$   $��16(�62   �� 54      $
��+21%��6$   
��� � �60   55      �� 56      $��10q�6!   .+�57      �� $��Total Profit��6$   $
��Bold"�68   �� 58      $��100000��6$   $��16(�62   �� 59      $
��+19%��6$   
��� � �60   5:      5;      �� 5>      $��1��6   
�������$��1q�69    �� CornerRadius$ 5��6M   $��	0,0,10,10q�6^   ._�5?      �   5@      �� 5A      $
��Auto �6,   �� 5B      $��* �6,   .+�5F      �� $ 
Horizontal=�6%   $��0��6>   $��10q�6K   .+�5G      �� $��Prendas en Producción: ��6(   $
��Bold"�6G   �� 5H      ��6(   �� *PrendasEnProduccion+5J      � 5M      $��1��6   $��10q�6,   .+�5N      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   Series 68   �� *ProduccionPorSemana+   AxisX 5P   &     LiveCharts.Wpf.Axis     Title$ Semana��66      AxisY 5S   &     $ Prendas Terminadas��66   5U      5V      &   System.Windows.Controls.DataGrid  5Y         AutoGenerateColumns$
 True��6L   ��6#   �� *MateriaPrimaBaja+6L     5\      $
 True��6P   ��6#   �� *ListaPagosPendientes+6P   5]      5^      � 5a      $��2��6   $��0,10,0,0q�6$    5b      �� 5c      $��2* �6+   �� 5d      $��3* �6+   .+�5g      �� $��0��6!   $��5q�61   .+�5h      �� $��Dashboard de Producción��6$   $
��Bold"�6C   $��18(�6U   $��0q�6c   �� 5j      $��Prendas en Producción:��6$   �� 5k      $
��Bold"�6I   $��6(�6[   ��6$   �� *PrendasEnProduccion+6[   �� 5m      $��Tejedoras Activas:��6$   �� 5n      $
��Bold"�6F   $��6(�6X   ��6$   �� *TejedorasActivas+6X   �� 5p      $��Pedidos en Producción:��6$   �� 5q      $
��Bold"�6I   $��6(�6[   ��6$   �� *PedidosEnProduccion+6[   �� 5s      $!��Stock de Materia Prima (g):��6$   �� 5t      $
��Bold"�6G   $��6(�6Y   ��6$   �� *StockMateriaPrima+6Y   5u      �� 5w      $��1��6   
�������$��1q�6@   $ 5��6T   $��5q�6e   ._�5x      �� $��Low Stock Products��6$   $��Center=�6>   $��Center=�6[   5y      5z      5{      �� 5~      $��1��6   
�������$��1q�68   $ 5��6L   $��10q�6]   ._�5      �� $1��+5 Best Selling Products (Chart Placeholder)��6   $��Center=�6O   $��Center=�6l   5�      5�      5�      5�      