   M S B A M L   `   `   `  ���� ?  ;Olib, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Olib.WindowsOlib.Windows  $    Olib.Windows.rouletteFM_Rename   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Olib.Windows     -     �Name$  Rename�� 
  Rename � Title# [  $��95��$	��320�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency .  � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��W�  �� 
TargetName$ ScaleWindow��	 �� TargetProperty$	 ScaleX�
 W� From$	
 0.8X�	 W� To$ 1X� g� DecelerationRatio$ 1Q� g� Duration$ 0:0:0.3D�W� $ ScaleWindow��$	 ScaleY�$	
 0.8X�$ 1X�$ 1Q�$ 0:0:0.3D�W� $ Rename��$	 Opacity�$
 0X�$ 1X�$ 0:0:0.3D�.���  J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� -   ScaleWindow�� �� ScaleX$ 1Q� �� ScaleY$ 1Q� � RowDefinitions �� $��35 ��� .+���  �� CornerRadius$ 3��  BackgroundControl#��[ $��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 -90Q�   
BlurRadius$ 20Q�   RenderingBias$ Quality=�   ShadowDepth$ 3Q�   Opacity$	 0.4Q�._��  ��  � ColumnDefinitions �� $
��Auto ��� $��1* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��0��$��0��$��10,0,0,0q�.+���   OlibDrawingImage#��[ $��16��$��0,0,2,0q��� $
��Olib��  ForegroundColor#��[ $��Center=�  	Bauhaus93#��[ $��14(��� -   $��3�����	#00000000 � ContextMenu �� .@�m� -   $��Закрыть�� m� InputGestureText$ Alt+F4�� m� Icon ��   closeDrawingImage#��[ $��12���� -    ��Name$ 
textHeader��#��[   K� ZIndex$ -1��$��1��$��0q�$��Center=�$��Center=�$��14(��� $ 
Horizontal=�$��2��.+���   HeadeButton#���  $��40��
������� :� $ Button.Click��.[��� .���� .��W� $ ScaleWindow��$	 ScaleX�$
 1X�$	 0.8X�  g� AccelerationRatio$  1Q�$ 0:0:0.2D�W� $ ScaleWindow��$	 ScaleY�$
 1X�$	 0.8X�$  1Q�$ 0:0:0.2D�W� -   $ Rename��$	 Opacity�$
 1X�$ 0X�$ 0:0:0.2D�.���� $��16��#��[ �� $��2��  BackgroundWindow#��[ $ 3��$	 -10��$y�Visible=�$��2���� $ 
Horizontal=�$��1��$��Center=�$��Center=�.+��� -   ! ��Name$! 
SelectItem��$	��190��$��0q�$��Center=�$��Center=�.��" � 	Resources" # �� 
TargetType$ �� Property% �� Value��%9   '��       �� "# ��.��� $ �@��CornerRadius$% 3��.���� #��[    GlobalButton#���  $��14(�$��5,0,0,0q�$
��10,0q� :� $ Button.Click��.[��� .���� -   .��W� $ ScaleWindow��$	 ScaleX�$
 1X�$	 0.8X�$  1Q�$ 0:0:0.2D�W� $ ScaleWindow��$	 ScaleY�$
 1X�$	 0.8X�$  1Q�$ 0:0:0.2D�W� $ Rename��$	 Opacity�$
 1X�$ 0X�$ 0:0:0.2D�