   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:EStore.WPF
EStore.WPF  5   	       EStore.WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:EStore.WPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         mainMenu �� 
TargetType �� Property �� Value  
gridHeader��%�   &	        &	 �     �� 5
   
   " o�6!   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��
 ���� 6+   5      �� 5   
   " �6$   .�5      ��  � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��9* �6   .+�5   
   � -   5         �Name$ 
gridHeader��5      $��0��6   #���  61   .+�5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��8* �6'   �� 5      $��1* �6'   .+�5!      �� $��0��6   $��0��6,   $��Nhóm4��69   �� 5#      $��0��6   $��1��6+   .+�5$      o� -   5         o�Name$ mainMenu��5$      #���   6-   .@�5%      m� -   5        $��Product��5%   4   $��Product��6#   64   m� 5&      -   5        $��Staff��5&   3   $��Staff��6#   63   m� 5'      -   5        	 m�Name$	 AdminProfilePage��5'   #   $��Profile��6=   $y�	Collapsed=�6m   m� 5(      -   5        $��Order��5(   2   $��Order��6#   62   m� 5)      -   5        $��Report��5)   3   $��Report��6#   63   5*      5+      �� 5-      $��0��6   $��2��6+   .+�5.      �� -   5        
 ��Name$
 	btnLogout��5.      $��Logout��60   $��Center=�6A   
���������5/      �� 50       �� Color$ Transparent��6/   52      53      54      55      � 56   
   -	   5        $ gridMain��56      $��1��6   .+�57       � -
   5          �Name$ 	frameMain��57      $��Stretch=�6'     � NavigationUIVisibility$ Hidden=�6C   � 58      -   5         �Name$ loadingProgressBar��58       � IsIndeterminate$
 True��67   $	��200��6N   $��20��6Z   $	��Top=�59      $��Center=�5:      $y�	Collapsed=�5;      $��	0,141,0,0q�62   5?      5A      5B      