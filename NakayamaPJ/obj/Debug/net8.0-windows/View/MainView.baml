   M S B A M L   `   `   `  ����E  ANakayamaPJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:NakayamaPJ.ViewNakayamaPJ.View  5   	   ;"clr-namespace:NakayamaPJ.ViewModelNakayamaPJ.ViewModel  5   	       NakayamaPJ.View.MainView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:NakayamaPJ.View     5   	   X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   2	ViewModel"clr-namespace:NakayamaPJ.ViewModel  5   	     � Title$  MainView��5
   	   $	��700��6   $
��1300��6'    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      (   "NakayamaPJ.ViewModel.MainViewModel  5   
    � 	Resources 5   
    �� DataType(   "NakayamaPJ.ViewModel.HomeViewModel   NakayamaPJ.View.HomeView*   $NakayamaPJ.ViewModel.PedidoViewModel    NakayamaPJ.View.PedidoView,   &NakayamaPJ.ViewModel.TejedoraViewModel"   NakayamaPJ.View.TejedoraView+   %NakayamaPJ.ViewModel.CalidadViewModel!	   NakayamaPJ.View.CalidadView,
   &NakayamaPJ.ViewModel.NotaPagoViewModel"   NakayamaPJ.View.NotaPagoView.   (NakayamaPJ.ViewModel.ProduccionViewModel$   NakayamaPJ.View.ProduccionView2   ,NakayamaPJ.ViewModel.SalidaMaterialViewModel(   "NakayamaPJ.View.SalidaMaterialView*   $NakayamaPJ.ViewModel.DesingViewModel    NakayamaPJ.View.DesingView)   #NakayamaPJ.ViewModel.EnvioViewModel   NakayamaPJ.View.EnvioView-   'NakayamaPJ.ViewModel.DashboardViewModel#   NakayamaPJ.View.DashboardView��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5!      *,
 +)(�� �     5$      *, +)(�� ,    5'      *, +)(�� ^    5*      *, +)(�� �    5-      *, +)(�� �    50      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5       �� 5!   
   " 
 6   .R�5"        5#      �� 5$   
   "  6   .R�5%        5&      �� 5'   
   "  6   .R�5(        5)      �� 5*   
   "  6   .R�5+        5,      �� 5-   
   "  6   .R�5.        5/      �� 50   
   "  6   .R�51        52      5:      .��5;      ��  �� CornerRadius$ 15��6   $��3q�5<   
    J� Opacity$ 1Q�5=   
   ��5?   
   �� 5@      	 �� 
StartPoint$		 0,0&�6"   
 �� EndPoint$	
 1,1&�63   .��5A      �    winBorderColor1 � Color# [  6    � Offset$ 0Q�6H   � 5B        winBorderColor2# [ 6   $	 0.5Q�6H   � 5C        winBorderColor3# [ 6   $ 1Q�6H   5E      ._�5H   
   �  � ColumnDefinitions 5I      �� 5K      $	��250 �6#   �� 5O      $
��652* �6#   �� 5P      $
��393* �6#   .+�5U      �� $ 	10,0,0,10��6   $��0��5V      ��5W      �� 5X      $		 0,0&�6*   $
 1,0.7&�6;   .��5Y      �   SecundaryBackColor1# [ 6'   $ 0Q�6T   � 5Z        SecundaryBackColor2# [ 6'   $
 0.75Q�6T   5[      ._�5]      �� .+�5_      ��  �� Orientation$ 
Horizontal=�6!   $��35��5`      $��
15,25,0,40q�5a      .+�5b      �� $!��/Imagenes/nakayama-icon.png��6    $��30��6E   �� 5c      $��NAKAYAMA DEL PERÚ��6$     TitleColor3#��[ 5d   !   $��15(�5e   !   $��	Monserrat)�5f   !   $��Medium"�5g   !   $��Center=�5h   !   $��5,0,0,0q�5i   !   5j      	� 5m        
menuButtom#��[ 6"    
 color1
 � Tag# [ 5n        d� 	IsChecked$
 TrueY�5p       ��5o      �� *MostrarHomeViewCommand+.��5q      �� $ 
Horizontal=�6%   .+�5r      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+     menuButtomIcon#��[ 67   �� 5s      $��Pagina Principal��6(    	 menuButtonText#��[	 6@   5t      5u      	� 5x      -   5        #��[ 5x   "    

 color2# [
 5y       ��5z      �� *MostrarPedidoViewCommand+.��5|      �� $ 
Horizontal=�6%   .+�5}        $
 Book=�6+   #��[ 67   �� 5~      $��Pedido��6(   #��[	 66   5      5�      	� 5�      -   5        #��[ 5�   "     color11# [ 5�   !   ��5�       �� *MostrarProduccionViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ CircleNodes=�6+   #��[ 6>   �� 5�      $��producción��6(   #��[	 6:   5�      5�      	� 5�      #��[ 6"    
 color3# [ 5�       ��5�      �� *" MostrarSalidaMaterialViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ CartFlatbed=�6+   #��[ 6>   �� 5�      $��Salida de material��6(   #��[	 6B   5�      5�      	� 5�      #��[ 6"    
 color6# [ 5�       ��5�      �� *MostrarNotaPagoViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ 
MoneyBill1=�6+   #��[ 6=   �� 5�      $��Nota De Pago��6(   #��[	 6<   5�      5�      	� 5�      -   5        #��[ 5�   "    
 color5# [ 5�       ��5�      �� *MostrarTejedoraViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ 	UserGroup=�6+   #��[ 6<   �� 5�      $��
Tejerdoras��6(   #��[	 6:   5�      5�      	� 5�      -   5        #��[ 5�   "    
 color8# [ 5�   "   ��5�   "   �� *MostrarDesingViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Shirt=�6+   #��[ 68   �� 5�      $��Diseños��6(   #��[	 67   5�      5�      	� 5�      -   5        #��[ 5�   "   # [ 5�   "   ��5�   "   �� *MostrarEnvioViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Truck=�6+   #��[ 68   �� 5�      $��Envío��6(   #��[	 65   5�      5�      	� 5�      #��[ 6"   # [ 5�       ��5�      �� *MostrarCalidadViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Award=�6+   #��[ 68   �� 5�      $��Control de Calidad��6(   #��[	 6B   5�      5�      	� 5�      #��[ 6"   # [ 5�       ��5�      �� *MostrarDashboardCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $	 Map=�6+   #��[ 66   �� 5�      $��	DashBoard��6(   #��[	 69   5�      5�      5�      5�      �� 5�      $ 	0,10,10,0��6   $��1��5�      $��2��6"   ��5�      �� 5�      $		 1,1&�6*   $
 1,0.7&�6;   .��5�      �   PrimaryBackColor1# [ 6'   $ 0Q�6R   � 5�        PrimaryBackColor2# [ 6'   $
 0.75Q�6R   5�      ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   �� 5�      $��40 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ PnlControlBar��5�   !   $��0��5�      $ 
Horizontal=�5�      $��RightToLeft=�5�      
������ $��0,0,5,0q�5�      .+�5�      �� -   5         ��Name$ BtmClose��5�   !     controlButtom#��[ 5�        color12# [ 5�      .��5�        $ Xmark=�6+     controlButtomIcon#��[ 68   5�      �� 5�      -   5        $ BtmMaximize��5�   !   #��[ 5�      # [ 5�      .��5�        $ WindowMaximize=�6+   #��[ 6B   5�      �� 5      -	   5        $ BtmMinimize��5   !   #��[ 5     # [ 5     .��5       $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5     5     � 5
     $��1��6    5     �� 5     $	��17* �6/   5     �� 5     $	��78* �6/   .+�5     �� $��0��6%   $ 
Horizontal=�5  "   $��Center=�5  "   .+�5       $��20��5  (   $��20��5  (     TitleColor2   
Foreground# [ 5  (   $��	35,0,10,0q�5  (    J� RenderTransformOrigin$	 1,1&�6;    5  +   �� *Icono+5  ;   �� 5     #��[ 5  %   $��16(�5  %   $��	Monserrat)�5  %   $��Medium"�5  %   $��Center=�5   %   ��5  (   �� *Titulo+5   %   5!     �� 5$     $��1��5%  "   $ 
Horizontal=�5&  "   $��RightToLeft=�5'  "   $��Center=�5(  "   $��0,0,10,0q�5)  "   $��2��64   .+�5*     ��   
iconButtom#��[ 6%   # [ 5+  "   .��5,  "     $ 	AngleDown=�6/     iconButtomIcon#��[ 6@   5-     �� 5.     #��[ 5/  (   $��12(�50  (   $��Center=�51  (   $��	Monserrat)�52  (   ��5.  (   �� *CurrentUserAcount.DisplayName+52  (   A� 53     $��40��6&   $��40��62   #��[ 54  #   $��2��55  #   $��	10,0,10,0q�56  #   ��57  "   �� 58  &    �� ImageSource$ /Imagenes/profile.jpeg��61   6X   5:     �� 5=     #��[ 6%   # [ 5>  "   .��5?  "     $ Clock=�6/   #��[ 6<   5@     �� 5C     #��[ 6%   # [ 5D  "   .��5E  "     $
 Fire=�6/   #��[ 6;   5F     �� 5I     #��[ 6%   # [ 5J  "   .��5K  "     $
 Moon=�6/   #��[ 6;   5L     5N     5P     �� 5S     $��2��5T  "   $��25q�5U  "   ��5S  %   �� *CurrentChildView+5U  "   5X     5Y     5[     5_     5b     