   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSHMS  5   	       HMS.book_appointment   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:HMS     5   	     � Title$  Book Appointment��5      $	��700��6(   $
��1000��65    � WindowStartupLocation$ CenterScreen=�6B    � 
ResizeMode$ 	CanResize=�6g    � ShowInTaskbar$
 True��6~   ��5	      �� 5
   
    �� ImageSource$ media/formbg.png��6   .��5      � .+�5   
   �� $��Book Appointment��6   
���   �$��40(�6>   $
��Bold"�6L   $��305,90,309,0q�6^   $	��Top=�6t   �� 5   
   $��Doctor��6   
���   �$��18(�64   $
��Bold"�6B   $
��Left=�6T   $��205,189,0,0q�6o   $	��Top=�6�   $��38��6�   $��80��6�   �� 5   
   $
��Date��6   
���   �$��18(�62   $
��Bold"�6@   $
��Left=�6R   $��205,255,0,0q�6m   $	��Top=�6�   $��34��6�   $��66��6�   �� 5   
   $
��Time��6   
���   �$��18(�62   $
��Bold"�6@   $
��Left=�6R   $��205,319,0,0q�6m   $	��Top=�6�   $��90��6�   �� 5   
   $��3q�6   ���	#FFDDDDDD
������� �� CornerRadius$ 10��6T   $	��Top=�6f    �� Padding$ 0q�6~   $��40��6�   $��369,388,317,0q�6�   ._�5      �� -   5        $
��BOOK��5      $��0q�6$   $��18(�68   $��4��6F   $
��Bold"�6S   $
��Left=�6e   $��Center=�6�   $��30��6�   $	��299��6�   $��7,0,0,0q�6�   6�   5      �� 5   
   $��3q�6   
���   �$ 20��69   $	��Top=�6K   $ 0q�6c   $��48��6o   $��296,180,244,0q�6{   ._�5      �� -   5         ��Name$ Doctor��5   /   
������ 
���   �$��0q�6R   $��1��6f    �� TextWrapping$
 Wrap=�6s   $��15(�6�   $��Center=�6�   $��28��6�   $��	23,0,23,0q�6�   5      �� 5   
   $��3q�6   
���   �$ 20��69   $	��Top=�6K   $ 0q�6c   $��48��6o   $��296,245,244,0q�6{   ._�5      �� -   5        $
 Date��5   /   
������ 
���   �$��0q�6P   $��2��6d   $
 Wrap=�6q   $��15(�6�   $��Center=�6�   $��28��6�   $��	23,0,23,0q�6�   5      �� 5   
   $��3q�6   
���   �$ 20��69   $	��Top=�6K   $ 0q�6c   $��48��6o   $��297,312,243,0q�6{   ._�5      �� -   5        $
 Time��5   /   
������ 
���   �$��0q�6P   $��3��6d   $
 Wrap=�6q   $��15(�6�   $��Center=�6�   $��28��6�   $��	23,0,23,0q�6�   5       �� 5"   
   $��3q�6   ���	#FFDDDDDD���	#FFDDDDDD$ 10��6T   $
��Left=�6f   $	��Top=�6�   $ 0q�6�   $��40��6�   $��42��6�   $��905,467,0,0q�6�   ._�5#      �� -   5        $��7��5#      $��0q�6"   $��5,1,5,1q�66   ���	#FFDDDDDD���	#FF0C0C0C.��5$      �� $��media/clear.png��6   $��24��61   $��23��6=   	 J� RenderTransformOrigin$	 0.5,0.5&�6H   $
��Fill=�6h   5%      5&      �� 5(   
   $��3q�6   ���	#FFDDDDDD
�������$ 10��6T   $	��Top=�6f   $ 0q�6~   $��72��6�   $��877,34,37,0q�6�   ._�5)      �� -   5        $��3��5)      $��0q�6"   $��13(�66   $
��Bold"�6D   $��6,1,7,0q�6V   ���	#FFDDDDDD
���   �$��64��6�   $	��Top=�6�   .��5*      �� $��media/homepage logo.png��6   $��40��69   $��51��6E   $	 0.507,0.557&�6P   $
��Fill=�6t   5+      5,      &   System.Windows.Controls.DataGrid  5.   
   -   5        
  Name$
 datagrid��5.         CanUserResizeColumns$ False��6%      CanUserReorderColumns$ False��6B      CanUserResizeRows$ False��6`      CanUserSortColumns$ False��6z      
IsReadOnly$
 True��6�   $   HorizontalScrollBarVisibility$ Visible=�5/         	RowHeight$ 30Q�6-      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 110 6<      GridLinesVisibility$ Vertical=�6N      HeadersVisibility$	 All=�6m   "   VerticalScrollBarVisibility$
 Auto=�6�   
���   �$��5q�50         SelectionMode$ Extended=�6-   
�������   RowBackground
 ����   AlternatingRowBackground
 �����$��115,466,113,13q�51   0   52      53      