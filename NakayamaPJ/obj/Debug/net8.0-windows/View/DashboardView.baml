   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      E ANakayamaPJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:NakayamaPJ.ViewNakayamaPJ.View 5      #   NakayamaPJ.View.DashboardView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      K
LiveCharts4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      /localclr-namespace:NakayamaPJ.View     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   $��0��6:   .+�5      (  "System.Windows.Controls.DatePicker  $��10,0,0,0q�6   �� 5      $��Ok��6   $��10,0,0,0q�6"   �� 5      $��Custom��6   $��10,0,0,0q�6&   �� 5      $��Today��6   $��10,0,0,0q�6%   �� 5      $��Last 7 Days��6   $��10,0,0,0q�6+   �� 5      $��Last 30 Days��6   $��10,0,0,0q�6,   �� 5      $��
This Month��6   $��10,0,0,0q�6*   5      � 5   
   $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��2* �6#   .+�5#      �   5$      �� 5%      $
��Auto �6$   �� 5&      $��* �6$   �� 5'      $
��Auto �6$   .+�5+      �� $ 
Horizontal=�6   $��Center=�66   $��0,0,0,20q�6S   .+�5,      �� $��10q�6!   $��Center=�6-   .+�5-      �� $��Prendas en Producción��6$   $
��Bold"�6A   �� 5.      $��16(�6I   ��6$   �� *PrendasEnProduccion+6I   5/      �� 50      $��10q�6!   .+�51      �� $��Tejedoras Activas��6$   $
��Bold"�6=   �� 52      $��16(�6F   ��6$   �� *TejedorasActivas+6F   53      �� 54      $��10q�6!   .+�55      �� $��Pedidos en Producción��6$   $
��Bold"�6A   �� 56      $��16(�6I   ��6$   �� *PedidosEnProduccion+6I   57      �� 58      $��10q�6!   .+�59      �� $ ��Stock de Materia Prima (g)��6$   $
��Bold"�6F   �� 5:      $��16(�6G   ��6$   �� *StockMateriaPrima+6G   5;      5<      �� 5?      $��1��6   
�������$��1q�69    �� CornerRadius$ 5��6M   $��	0,0,10,10q�6^   ._�5@      �   5A      �� 5B      $
��Auto �6,   �� 5C      $��* �6,   .+�5G      �� $ 
Horizontal=�6%   $��0��6>   $��10q�6K   .+�5H      �� $��Producción por Semana��6(   $
��Bold"�6E   $��14(�6W   5I      #   LiveCharts.Wpf.CartesianChart  5L      $��1��64   &    LiveCharts.Wpf.Charts.Base.Chart   Series 6A   �� *ProduccionSemanal+   AxisX 5N   "      LiveCharts.Wpf.Axis     Title$ Semana��62      AxisY 5Q   "     $ Prendas Terminadas��62   5S      5T      5U      5V      �� 5Y      $��1��6   
�������$��1q�68   $ 5��6L   $��10q�6]   ._�5Z      &   System.Windows.Controls.DataGrid  ��6   �� *PagosPendientes+   Columns 5[      0  *System.Windows.Controls.DataGridTextColumn  5\      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nombre��6-   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *NombreTejedora+  5]      $	 Apellido��6-   
 6?   �� *ApellidoTejedora+  5^      $	 Monto��6-   
 6<   �� *Monto+  5_      $	 Fecha de Pago��6-   
 6D   �� *	FechaPago+5a      5c      5d      5e      5f      