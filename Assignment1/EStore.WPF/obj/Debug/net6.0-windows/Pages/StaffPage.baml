   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EStore.WPF.PagesEStore.WPF.Pages  5           EStore.WPF.Pages.StaffPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:EStore.WPF.Pages     5        N� Title$  	StaffPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%R   '�       �� 5      " �6   .�5   
   ��  � ��$ 10q�6#   5      5      .��5      � $��10,10,10,10q�6   
����ح� � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��6* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��6* �6#   �� 5      $��4* �6#   .+�5      �� $��0��6   $��0��6&   $
��Left=�66   $	��200��6Q   .+�5      �� $��StaffId��6   6,   �� 5      -   5         ��Name$ 
txtStaffId��5       �� 
IsReadOnly$
 True��6.   6B   �� 5      $
��Name��6   6)   �� 5      -   5        $ txtName��5      6-   �� 5      $��Password��6   6-   �� 5      -   5        $ txtPassword��5      61   5       �� 5"      -   5        	 ��Name$	 searchPanel��5"      $��1��6.   $��0��6;   $��Right=�6K   $	��200��6g   .+�5#      �� $��Search��6   6+   �� 5$      -   5        $ 	txtSearch��5$      6/   �� 5%      -   5        
 ��Name$
 	btnSearch��5%      $��Search��6,   $��50��6=   6b   5&      �� 5(      $��0��6   $��1��6&   .+�5)      �� -   5        $
 btnAdd��5)      $	��Add��6)   $��50��67   $��10q�6B   6e   �� 5*      -   5        $
 	btnUpdate��5*      $��Update��6,   $��50��6=   $��10q�6H   6n   �� 5+      -	   5        $
 	btnDelete��5+      $��Delete��6,   $��50��6=   $��10q�6H   6n   5,      5-      � 5.   
   $��1��6   .+�5/      �� $
��Left=�6   .+�50      �� -
   5         ��Name$ staffListView��50       �� View 51      �� 52      .P�53      �� $��StaffId��6-    �� Width$	 100��6g    �� DisplayMemberBinding 6>   �� *	StaffId+6g   �� 54      $
��Name��6-   $	 150��6a    6;   �� *Name+6a   �� 55      $��Password��6-   $	 150��6i    6?   �� *
Password+6i   56      58      59      5:      5;      5<      