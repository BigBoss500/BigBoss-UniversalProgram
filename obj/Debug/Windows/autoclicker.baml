   M S B A M L   `   `   `  ����?  ;Olib, Version=2.3.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Olib.WindowsOlib.Windows  5   	       Olib.Windows.autoclicker   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Olib.Windows     5   	   -   5          �Name$  AutoclickerW��5   	    � Title$ Autoclicker��5	   	   $	��180��6   $	��325��6*    � 
ResizeMode$ NoResize=�66    � WindowStyle$
 None=�6L   
������  � AllowsTransparency .  � Triggers 5
      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ ScaleWindow��6&    �� TargetProperty$ ScaleX�6J   	 W� From$		 0.8X�6m   	
 W� To$
 1X�6x    g� DecelerationRatio$ 1Q�6    g� Duration$ 0:0:0.3D�6�   W� 5      $ ScaleWindow��6&   $ ScaleY�6J   $		 0.8X�6m   $
 1X�6x   $ 1Q�6   $ 0:0:0.3D�6�   W� 5      $ AutoclickerW��6&   $ Opacity�6K   $	 0X�6o   $
 1X�6x   $ 0:0:0.3D�6   5      5      5      .��5      �  J� RenderTransformOrigin$ 0.5,0.5&�6   z�5   
   V� 5      .~�5      �� -   5        ScaleWindow�� �� ScaleX$ 1Q�5   6    �� ScaleY$ 1Q�6A   5       � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      .+�5   
   ��  �� CornerRadius$ 3��6      BackgroundControl#��[  6"   $��0��6R    J� Effect 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!         	Direction$	 -90Q�6#      
BlurRadius$ 20Q�63      RenderingBias$ Quality=�6C      ShadowDepth$ 3Q�6[      Opacity$	 0.4Q�6k   ._�5#      �  5$      �� 5%       � ColumnDefinitions 5'      �� 5(      $
��Auto �6'   �� 5)      $��1* �6'   �� 5*      $
��Auto �6'   .+�5-      ��  �� Orientation$ 
Horizontal=�6   $��0��66   $��0��6C   $��10,0,0,0q�6S   .+�5.      ��   OlibDrawingImage#��[ 6   $��16��6G   $��0,0,2,0q�6R   �� 5/      $
��Olib��6    $��Center=�6,     ForegroundColor#��[ 6G     	Bauhaus93#��[ 6u   $��14(�6�   50      �� 51      -   5        $��3��51      ���	#00000000 � ContextMenu 52      �� 53      .@�54      m� -   5        $��Скрыть��54   '    m� Icon 55   "   �� 56   &     hideDrawingImage#��[ 6,   $��12��6W   58      �� 59        Sep#��[ 6(   m� 5:      -   5        $��Закрыть��5:   '    m� InputGestureText$ Alt+F4��6O    5;   "   �� 5<   &     closeDrawingImage#��[ 6,   $��12��6X   5>      5?      5A      �� 5B      -   5         ��Name$ 
textHeader��5B       K� ZIndex$ -1��6`   $��1��6r   $��0q�6�   $��Center=�6�   $��Center=�6�   $��14(�6�   ��6,   �� *Title+ �� ElementName$ AutoclickerW��6�   �� 5C      $ 
Horizontal=�6   $��2��66   .+�5D      �� -   5          HeadeButton#���  5D      $��40��6C   
�������.��5E      �� $��16��6    #��[ 6+   5F      �� 5G      #���  6   $��40��6C   
������� 5H      :� 5I      $ Button.Click��6+   .[�5J   "   �� .��5K   &   �� -   5        .��5L   *   W� $ ScaleWindow��6:   $ ScaleX�6^   $	 1X�6�   $	
 0.8X�6�     g� AccelerationRatio$  1Q�6�   $ 0:0:0.2D�6�   W� 5M   *   $ ScaleWindow��6:   $ ScaleY�6^   $	 1X�6�   $	
 0.8X�6�   $  1Q�6�   $ 0:0:0.2D�6�   W� 5N   *   $ AutoclickerW��6:   $ Opacity�6_   $	 1X�6�   $
 0X�6�   $ 0:0:0.2D�6�   5O   '   5P   #   5Q      .��5S      �� $��16��6    #��[ 6+   5T      5U      5V      5W      �� 5X   
   $��2��6     BackgroundWindow#��[ 6"   $ 3��6Q   $	 -10��6b   $y�Visible=�6u   $��2��6�   �� 5Y   
   $��1��6   .+�5Z      ��  		 InfoA#��[	 6    
 ForWindowColor#��[
 65   $��14(�6b   $��Center=�6p   �� 5[       	 TimeA#��[ 6   #��[
 65   $��14(�6b   $��Center=�6p   �� 5\      -	   5        ! ��Name$! TextTime��5\      $	��500��6(   $��	10,5,10,0q�63   $��0q�6F   $��5q�6Z   $��Center=�6f   $��14(�6�   .��6�   " � 	Resources" 5]      # �� 
TargetType$ �� Property% �� Value��%^   '��       �� 5^      "# ��6   .�5_      �� $ �@��CornerRadius$% 3��69   5`      5a      .��6%    5b        5c      $	 -90Q�6'   $ 10Q�67   $ Quality=�6G   $ 1Q�6_   $	 0.4Q�6o   .��5d   "   5e      �� 5f        Warning#��[ 6   $��0,10,0,0q�67   
���  ��$��14(�6Z   $��Center=�6h    5g        5h      -
   5        Warning��$ 0Q�5h   8   $ 0Q�6G   &   Color$	& Red��6W   5j      5k      5l      5m      