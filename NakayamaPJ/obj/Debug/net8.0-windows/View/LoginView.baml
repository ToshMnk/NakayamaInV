   M S B A M L   `   `   `  ����E  ANakayamaPJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:NakayamaPJ.ViewNakayamaPJ.View  5   	   ;"clr-namespace:NakayamaPJ.ViewModelNakayamaPJ.ViewModel  5   	   E'clr-namespace:NakayamaPJ.CustomControlsNakayamaPJ.CustomControls  5   	       NakayamaPJ.View.LoginView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:NakayamaPJ.View     5   	   8	ViewModel"clr-namespace:NakayamaPJ.ViewModel     5   	   Bcustomcontrols'clr-namespace:NakayamaPJ.CustomControls     5   	   -   5          � Title$  	LoginView��5
   	   $	��550��6   $	��800��6(    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      )   #NakayamaPJ.ViewModel.LoginViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5#      �� 
 �� CornerRadius$
 28��6   ��5$   
   �� 5%       �� ImageSource$ /Imagenes/fondo.jpg��6    j� Stretch$ UniformToFill=�5&      ._�5(   
   �� $
 15��6   $��3q�5)   	    J� Opacity$
 0.90Q�5*   	   ��5,      �� 5-       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5.      �   winBorderColor1 � Color# [ 6#    � Offset$ 0Q�6L   � 5/        winBorderColor2# [ 6#   $	 0.5Q�6L   � 50        winBorderColor3# [ 6#   $ 1Q�6L   52      ��55      �� 56      $	 1,0&�6&   $	 0,1&�67   .��57      �   SecundaryBackColor1# [ 6#   $
 0.90Q�6P   � 58        PrimaryBackColor1# [ 6#   $ 0Q�6N   59      ._�5<      �  � RowDefinitions 5=      �� 5>      $��30 �6$   �� 5?      .+�5B      �  � ColumnDefinitions 5C      �� 5D      �� 5E      $��25 �6+   �� 5F      $��25 �6+   �� 5G      $��5 �6+   .+�5J      �� $��LOG-IN��6      TitleColor1#��[ 5K      $��10(�5L      $��
Montserrat)�5M      $��0��5N      $��Center=�5O      $��10,0,0,0q�5P      �� 5U      -   5         ��Name$ BtmMinimize��5U      $��0q�5V      $��-��5W      
�������$��16(�5Y      $��	Monserrat)�5Z       � Cursor$
 Hand��5[      $��1��5\      ��5^      �� 5_       �� 
TargetType" ��6$   .�5`   "   ��  �� Property � �� �� Value �#003a616?    �� Triggers 5a   "   P� 5b   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5c   *   ��  � �� �#48b5ff6G   5d   '   5f      ��5i      �� 5j       �� 
TargetType" ��6.   .R�5k   "   �� $��18��6)   $��18��64   $
 9��5l   %   #��z��5m   %   ._�5n   &   �� $��Center=�67   $��Center=�5o   3   5p   #   5q      5t      �� 5y      -   5        $ BtmClose��5y      $��0q�5z      $��X��5{      
�������$��12(�5}      $��	Monserrat)�5~      $
 Hand��5      $��2��5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#003a616?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#48b5ff6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $��18��6)   $��18��64   $
 9��5�      #��z��5�      ._�5�   &   �� $��Center=�67   $��Center=�5�      5�   #   5�      5�      5�      �� 5�      $	��250��6   $��2��5�       �� Orientation$ Vertical=�5�      $��0,35,0,0q�5�      .+�5�      �� $!��/Imagenes/nakayama-icon.png��6   $	��150��5�      $	��150��6$   �� 5�      $��NAKAYAMA DEL PERÚ S.A.C.��6    
�������$��	Monserrat)�5�      $��19(�5�      $��Medium"�5�      $��Center=�5�      �� 5�      $��Trading and Marine Div��6    
�������$��	Monserrat)�5�      $��13(�5�      $��Medium"�5�      $��Center=�5�      $��0,5,0,0q�5�      �� 5�      $��Usuario��6    
���   �$��	Monserrat)�5�      $��14(�5�      $��Medium"�5�      $��0,45,0,0q�5�      �� 5�      -   5         ��Name$ txtUser��5�      $��12(�5�      $��Medium"�5�      $��	Monserrat)�5�      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      $��22,0,0,0q�5�      ��5�      �� *
Username+  �� UpdateSourceTrigger$  PropertyChanged=�.��5�   -   ��5�      �� 5�      $ /Imagenes/icon-user.png��6)   $
 None=�5�   %   ! j� 
AlignmentX$
! Left=�5�   %   .��5�   .   5�      �� 5�      $��Contraseña��6    
���   �$��	Monserrat)�5�      $��14(�5�      $��Medium"�5�      $��0,10,0,0q�5�      3   -NakayamaPJ.CustomControls.BindablePasswordBox  5�      $��28��5�   )   $��0,5,0,0q�5�   )   "   Password" 5�   9   �� *
Password+$ TwoWay=�$  PropertyChanged=�5�      �� 5�      
���  ��$��	Monserrat)�5�      $��14(�5�      $��Medium"�5�      $��0,10,0,0q�5�      $
��Wrap=�5�      ��5�       �� *ErrorMessage+5�      �� 5�      -   5        $ btmLogin��5�      $��0q�5�      $��Ingresar��5�      
�������$��16(�5�      $��	Monserrat)�5�      $
 Hand��5�      $��1��5�      $��0,40,0,0q�5�      ��5�      �� *LoginCommand+��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#00253e6?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#48b5ff6G   5�   '   5�      ��5      �� 5     " ��6.   .R�5  "   �� $	��150��6)   $��40��65   $
 20��5  %   #��z��5  %   ._�5  &   �� $��Center=�67   $��Center=�5  3   5  #   5     5     5     5     5     5     5     