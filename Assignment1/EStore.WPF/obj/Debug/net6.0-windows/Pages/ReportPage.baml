   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EStore.WPF.PagesEStore.WPF.Pages  5      !    EStore.WPF.Pages.ReportPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:EStore.WPF.Pages     5        N� Title$  	OrderPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%W   '�       �� 5   
   " �6   .�5      ��  � ��$ 10q�6'   64   5      5      .��5      � $��10q�6   
����ح� � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��6* �6   .+�5   
   � $��0��6   $��0��6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��3* �6#   �� 5      $��4* �6#   .+�5      � $��0��6   $��0��6    5      � 5      $��0��6   $��2��6     5      �� 5      $��7* �6$   �� 5       $��3* �6$   .+�5"      �� $��0��6   .+�5#      �� -   5         ��Name$ orderDetailsListView��5#      $	��150��6=    �� View 5$      �� 5%      .P�5&   "   �� $��OrderDetail ID��61   	 �� Width$	 80��6x   
 �� DisplayMemberBinding
 6I   �� *OrderDetailId+6x   �� 5'   "   $��
Product ID��61   $	 80��6p   
 6E   �� *	ProductId+6p   �� 5(   "   $��Product Name��61   $	 80��6z   
 6G   �� *Product.ProductId+6z   �� 5)   "   $��Quantity��61   $	 80��6m   
 6C   �� *
Quantity+6m   �� 5*   "   $��Price��61   $	 80��6k   
 6@   �� *	UnitPrice+6k   5+      5-      5.      �� 5/      $��1��6    �� Orientation$ 
Horizontal=�6+   $��Right=�6D   .+�50      �� $��Total��6   $��50��6,   $��30��67   6H   �� 51      -   5         ��Name$ txtTotalPriceDetail��51   *   $	��100��6   $��30��6G   $��0,5,0,10q�6V   6j   52      53      54      � 55   
   $��1��6   $��1��6   .+�56      � $��1��6    57      �� 58      $��1* �6$   �� 59      $��9* �6%   .+�5;      �� $��0��6   .+�5<      o� -   5         o�Name$ menuFilterOrders��5<      $	��200��65   $
��Left=�6B   .@�5=      m� -   5        $
��Date��5=   2   $
��Date��6#   .@�5>      �� $��Start��6%   $��30��65   (  "System.Windows.Controls.DatePicker  5?      -   5          Name$ 	StartDate��5?   )   $��25��6<   �� 5@      $	��End��6%   $��30��63     5A      -   5        $ EndtDate��5A   )   $��25��6;   �� 5B      -   5         ��Name$ btnDateFilter��5B   %   $
��Save��6<   $��25��6K   5C      m� 5D      -   5        $��Staff��5D   2   $��Staff��6#   .@�5E      �� -	   5         ��Name$ 	cobStaffs��5E   (    �� SelectedIndex$ 0��6;   5F      5G      5H      �� 5I      $��1��6   .+�5J      �� -
   5        $ orderListView��5J      $��1��66   $	��200��6C   $	��250��6S    5K      �� 5L      .P�5M   "   �� $��Order ID��61   $		 100��6l   
 6C   �� *	OrderId+6l   �� 5N   "   $��	OrderDate��61   $		 150��6o   
 6D   �� *	OrderDate+6o   �� 5O   "   $��
Staff Name��61   $		 150��6q   
 6E   �� *
Staff.Name+6q   5P      5R      5S      5T      5U      5W      5X      