   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EStore.WPF.Windows.OrdersEStore.WPF.Windows.Orders  5   	   +    %EStore.WPF.Windows.Orders.CreateOrder   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:EStore.WPF.Windows.Orders     5   	     � Title$  CreateOrder��5   	   $	��450��6   $	��800��6*    � 	Resources 5	       �� 
TargetType �� Property �� Value��%w   '�       �� 5
   
   " �6   .�5      ��  � ��
 ��ح�6-   �� 5       � ��$ 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��6* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��5* �6#   �� 5      $��5* �6$   .+�5      �� $��0��6   $	��200��6)   $
��Left=�66   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�66   .+�5      �� $��Id��6   $��50��6)   $
��Left=�64   �� 5      -   5         ��Name$ txtId��5      $	��100��6.   $
��Left=�6:   5      �� 5      $ 
Horizontal=�6   $��5q�66   .+�5      �� $
��Name��6   $��50��6+   $
��Left=�66   �� 5       -   5        $ txtName��5       $	��140��60   5!      �� 5"      $ 
Horizontal=�6   $��5q�66   .+�5#      �� $��Quantity��6   $��50��60   $
��Left=�6;   �� 5$      -   5        $ txtQuantity��5$      $��50��63   $
��Left=�6>   5%      �� 5&      $ 
Horizontal=�6   $��5q�66   .+�5'      �� $��Price��6   $��50��6-   $
��Left=�68   �� 5(      -   5        $ txtPrice��5(      $��50��61   $
��Left=�6<   5)      5*      �� 5+      $��0��6   $��Right=�6*   $	��100��6F   .+�5,      �� -   5        	 ��Name$	 btnAdd��5,      $	��Add��6)   $��50��67   $��10q�6C   �� 5-      -   5        $	 	btnUpdate��5-      $��Update��6,   $��50��6=   $��10q�6H   �� 5.      -   5        $	 	btnDelete��5.      $��Delete��6,   $��50��6=   $��10q�6H   5/      �� 50      $��1��6   .+�51      �� -   5        
 ��Name$
 orderDetailsListView��51      $	��120��69    �� View 52      �� 53      .P�54      �� $	��Stt��6-    �� Width$ 50��6i    �� DisplayMemberBinding 6:   �� *OrderDetailId+6i   �� 55      $��
Product ID��6-   $ 80��6l    6A   �� *	ProductId+6l   �� 56      $��Product Name��6-   $ 80��6x    6C   �� *Product.ProductName+6x   �� 57      $��Quantity��6-   $ 80��6i    6?   �� *
Quantity+6i   �� 58      $��Price��6-   $ 80��6g    6<   �� *	UnitPrice+6g   59      5;      �� 5<      $ 
Horizontal=�6   .+�5=      �� $��Total��6   $��50��6,   $
��Left=�67   �� 5>      -	   5        $ txtTotal��5>      $	��100��60   $
��Left=�6<   �� 5?      -
   5        $	 btnSave��5?      $
��Save��6.   $	��100��6=   $��Right=�6I   5@      5A      5B      �� 5C   
   -   5        $
 productListView��5C      $��1��6,    5D      �� 5E      .P�5F      �� $��ID��6%   $ 50��6\    61   �� *	ProductId+6\   �� 5G      $
��Name��6%   $	 150��6`    63   �� *ProductName+6`   �� 5H      $��Category��6%   $	 100��6n    67   �� *Category.CategoryName+6n   �� 5I      $��Price��6%   $	 100��6_    64   �� *	UnitPrice+6_   5J      5L      5M      5N      