   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EStore.WPF.PagesEStore.WPF.Pages  5      '    !EStore.WPF.Pages.AdminProfilePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:EStore.WPF.Pages     5        N� Title$  AdminProfilePage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%R   '�       �� 5   
   " �6   .�5      ��  � ��$ 10q�6'   5      5      .��5      � $��10,10,10,10q�6   
����ح� � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��6* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��6* �6#   �� 5      $��4* �6#   .+�5      �� $��0��6   $��0��6&   $
��Left=�66   $	��200��6Q   .+�5      �� $
��Name��6   6)   �� 5      -   5         ��Name$ txtName��5      ��6+   �� *Name+6C   �� 5      $��Password��6   6-   �� 5      -   5        $ txtPassword��5      ��6/   �� *
Password+6K   5      �� 5      $��0��6   $��1��6&   .+�5!      �� -   5         ��Name$ 	btnUpdate��5!      $��Update��6,   $��50��6=   $��10q�6H   6n   5"      5#      � 5$   
   $��1��6   .+�5%      �� $
��Left=�6   .+�5'      �� -   5        	 ��Name$	 staffListView��5'      
 �� View
 5(      �� 5)      .P�5*      �� $
��Name��6-    �� Width$	 150��6a    �� DisplayMemberBinding 6;   �� *Name+6a   �� 5+      $��Password��6-   $	 150��6i    6?   �� *
Password+6i   5,      5.      5/      50      51      52      