   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSHMS  5   	       HMS.update_information   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:HMS     5   	     � Title$  Patient information��5   !   $	��700��6>   $
��1000��6K    � 
ResizeMode$ 	CanResize=�6X    � WindowStartupLocation$ CenterScreen=�6o    � Icon$ media/icon.png��6�    � ShowInTaskbar$
 True��6�   ��5	      �� 5
   
    �� ImageSource$ media/formbg.png��6   .��5      � .+�5   
   �� -   5        $��UPDATE��5      $��8��6"   $��15(�6/   $
��Bold"�6=   $
��Left=�6O   $��595,412,0,0q�6j   $	��Top=�6   $��34��6�   $��82��6�   5      �� 5   
   -   5         ��Name$
 Name��5      $��1��6    $
��Left=�6-   $��259,155,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��210��6�   $��37��6�   �� 5   
   -   5        $ Email��5      $��2��6!   $
��Left=�6.   $��668,155,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��210��6�   $��37��6�   G� 5   
   -   5         G�Name$ Password��5      $��3��6(   $
��Left=�65   $��259,206,0,0q�6P   $	��Top=�6e   $	��210��6}   $��37��6�   �� 5   
   -   5        $ Phone��5      $��5��6!   $
��Left=�6.   $��259,250,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��210��6�   $��37��6�   �� 5   
   -   5        $ Gender��5      $��6��6"   $
��Left=�6/   $��667,254,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��210��6�   $��37��6�   �� 5   
   -   5        $	 Age��5      $��4��6   $
��Left=�6,   $��668,204,0,0q�6G   $
 Wrap=�6\   $	��Top=�6p   $	��210��6�   $��37��6�   �� 5   
   -   5        $ Search��5      $��7��6"   $
��Left=�6/   $��358,410,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��210��6�   $��38��6�   �� 5   
   $��Patient Portal��6   $��30(�6)   $
��Bold"�67   $��380,67,287,0q�6I   $	��Top=�6_   �� 5   
   $
��Name��6   $��20(�6   $
��Bold"�6-   $
��Left=�6@   $��116,155,0,0q�6[   $	��Top=�6p   �� 5   
   $��Email��6   $��20(�6    $
��Bold"�6.   $
��Left=�6@   $��525,155,0,0q�6[   $	��Top=�6p   �� 5   
   $��Password��6   $��20(�6#   $
��Bold"�61   $
��Left=�6C   $��116,202,0,0q�6^   $	��Top=�6s   �� 5   
   $��Phone��6   $��20(�6    $
��Bold"�6.   $
��Left=�6@   $��116,250,0,0q�6[   $	��Top=�6p   �� 5   
   $��Gender��6   $��20(�6!   $
��Bold"�6/   $
��Left=�6A   $��525,258,0,0q�6\   $	��Top=�6q   �� 5   
   $	��Age��6   $��20(�6   $
��Bold"�6,   $
��Left=�6>   $��525,206,0,0q�6Y   $	��Top=�6n   �� 5    
   $��3q�6   ���	#FFDDDDDD
�������	 �� CornerRadius$	 10��6T   $	��Top=�6f   
 �� Padding$
 0q�6~   $��72��6�   $��877,34,37,0q�6�   ._�5!      �� -	   5        $��3��5!      $��0q�6"   $��13(�66   $
��Bold"�6D   $��6,1,7,1q�6V   ���	#FFDDDDDD
���   �.��5"      �� $��media/homepage logo.png��6   $��40��69   $��51��6E    J� RenderTransformOrigin$ 0.507,0.557&�6P   $
��Fill=�6t   5#      5$      &   System.Windows.Controls.DataGrid  5&   
   -
   5          Name$ datagrid��5&         CanUserResizeColumns$ False��6%      CanUserReorderColumns$ False��6B      CanUserResizeRows$ False��6`      CanUserSortColumns$ False��6z      
IsReadOnly$
 True��6�   $   HorizontalScrollBarVisibility$ Visible=�5'         	RowHeight$ 30Q�6;      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 110 6J      GridLinesVisibility$ Vertical=�6\      HeadersVisibility$	 All=�6{   "   VerticalScrollBarVisibility$
 Auto=�6�   
���   �$��5q�5(   '      SelectionMode$ Extended=�6;   
�������   RowBackground
 ����   AlternatingRowBackground
 �����$��114,461,114,18q�5)   >   �� 5+   
   $��3q�6   ���	#FFDDDDDD���	#FFDDDDDD$	 10��6T   $	��Top=�6f   $
 0q�6~   $��49��6�   $��905,469,29,0q�6�   ._�5,      �� -   5        $��9��5,      $��0q�6"   $��5,1,5,1q�66   ���	#FFDDDDDD���	#FF0C0C0C.��5-      �� $��media/clear.png��6   $��37��61   $��32��6=   $ 0.5,0.5&�6H   $
��Fill=�6h   5.      5/      50      51      