   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EStore.WPF.PagesEStore.WPF.Pages  5           EStore.WPF.Pages.OrderPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:EStore.WPF.Pages     5      -   5          N� Title$  	OrderPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '�       '�� H     �� 5   
   " �6   .�5      ��  � ��$ 10q�6(   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      $��4* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��6* �6#   �� 5      $��5* �6#   .+�5      �� $��0��6   $��0��6&   .+�5      �� .+�5      �� $
��Date��6    .��5      ��  �� Orientation$ 
Horizontal=�6%   .+�5       �� $ 
Horizontal=�6)   .+�5!   "   �� $
��Date��6)   (  "System.Windows.Controls.DatePicker  5"   "   -   5          Name$ pickerStartDate��5"   -   6F   5#      5$      5%      5&      �� 5'      .+�5(      �� $��Create Order��6   .��5)      �� $��0,0,0,0q�6%   $	��168��66   .+�5*      �  5+   "   �� 5,   &   $��5* �64   �� 5-   &   $��5* �64    5/   "   �� 50   &   $��5* �67   �� 51   &   $��5* �67   .+�53   "   �� $��0��6-   $��0��6:   $ 
Horizontal=�6J   $��5q�6c   .+�54   &   �� $��	ProductId��6,   $��60��6@   �� 55   &   -   5        	 ��Name$	 txtProductId��55   .   $	��120��6D   6P   56   #   �� 57   "   $��0��6.   $��1��6;   $ 
Horizontal=�6K   $��5q�6d   .+�58   &   �� $
��Name��6,   $��60��6;   �� 59   &   -   5        $	 txtProductName��59   .   $	��120��6F   5:   #   �� 5;   "   $��1��6.   $��0��6;   $ 
Horizontal=�6K   $��5q�6e   .+�5<   &   �� $��Quantity��6,   $��60��6?   �� 5=   &   -   5        $	 txtQuantity��5=   .   $	��120��6C   5>   #   �� 5?   "   $��1��6-   $��1��6:   $ 
Horizontal=�6J   $��5q�6c   .+�5@   &   �� $��	UnitPrice��6,   $��60��6@   �� 5A   &   -   5        $	 txtUnitPrice��5A   .   $	��120��6D   5B   #   5C      �� 5D      $ 
Horizontal=�6)   $��Center=�6B   .+�5E   "   �� -   5        $��
Add Detail��5E   )   $��	10,0,10,0q�6>   6Q   �� 5F   "   -   5        $��Order��5F   )   $
��Left=�6M   5G      5H      5I      5J      5K      �� 5L      $��0��6   $��1��6&   .+�5M      �� $��Order  Details��6   .��5N      �� .+�5O      &   System.Windows.Controls.DataGrid  -	   5        
  Name$
 dataGridOrderDetails��5O   #      AutoGenerateColumns$ False��6A      CanUserAddRows$ False��6]   $	��170��6t      Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q   "   ,  &System.Windows.Controls.DataGridColumn   Header$ OrderDetail ID��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *OrderDetailId+6o     5R   "   $ Product��65   $ * 6n    6F   �� *Product.ProductName+6n     5S   "   $ Quantity��65   $ * 6d    6G   �� *
Quantity+6d     5T   "   $ 
Unit Price��65   $ * 6g    6I   �� *	UnitPrice+6g   4  .System.Windows.Controls.DataGridTemplateColumn  5U   "   $ Actions��69   $ * 6J   -
   5        actionsColumn��   CellTemplate 5V   &   �� 5W   *   .R�5X   .   �� $ 
Horizontal=�69   $��Center=�6R   .+�5Y   2   �� -   5        $��Delete��5Y   9   
 � Tag$ Delete��6k   5Z   /   5[   +   5]   #   5_      �� 5`      -   5         ��Name$ 
lableTotal��5`   2   $��Total: ��6    $��80��6G   $��Right=�6R   5a      5b      5d      5e      � 5f   
   $��1��6   .+�5g      �� .+�5h      �� $��Orders��6   .��5i        -   5        $
 dataGridOrders��5i      $ False��67   $ False��6T   $	��150��6k    5j        5k      $ OrderId��61   $ * 6^    6B   �� *	OrderId+6^     5l      $ 
Order Date��61   $ * 6c    6E   �� *	OrderDate+6c     5m      $ Actions��65   $ * 6F    5n   "   �� 5o   &   .R�5p   *   �� $ 
Horizontal=�65   $��Center=�6N   .+�5q   .   �� -   5        $��Delete��5q   5   $ Delete��6a   �� 5r   .   -   5        $��Details��5r   5   $ Detail��6b   5s   +   5t   '   5v      5y      5z      5{      5|      5}      5~      