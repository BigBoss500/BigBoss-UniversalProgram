   M S B A M L   `   `   `  ���� ?  ;Olib, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Olib.Pages
Olib.Pages  clr-namespace:OlibOlib  %clr-namespace:Olib.Core	Olib.Core      Olib.Pages.darkChat   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Olib.Pages     %local1clr-namespace:Olib     %eclr-namespace:Olib.Core     -     N� Title$  	Dark Chat��.���  � RowDefinitions �� $��50 ��� �� $��30 ��� $��50 �.+��� ._���  �� Orientation$ 
Horizontal=�$��10q�$��Center=�.+��� -    ��Name$ 
tbIPAdress��$	��100��$��Center=�!   Olib.Core.TextboxExtensions   Placeholder$ IP���� -   $ tbHost��$��50��$	��5,0q�$��Center=�   Port# [  �� -   $ tbNick��$	��125��$��Center=�  Nick# [ �� -    ��Name$ 
bConnected��  GlobalButton#���  $
��10,0q�$��10,0,0,0q�  Connect#��[ �� -   #���  $
��10,0q�$��5,0,0,0q�  OpenHost#��[ �� -    ��Name$ lbChat��$��1��$
��10,0q�$��0q��� -    ��Name$ Error��$��2��
���  ��$��Center=�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  -	   Warning��	   
BlurRadius$	 0Q�
   ShadowDepth$
 0Q�   Color$	 Red���� $��3��._��  � ColumnDefinitions �� �� $
��Auto �.+��� -
   $ 	tbMessage��$��10q��� -   $��1��#���  $��
0,10,10,10q�$
��10,0q� 
 Submit#��[ 