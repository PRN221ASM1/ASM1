   M S B A M L   `   `   `  ����E  AEStore.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EStore.WPF.PagesEStore.WPF.Pages  5      "    EStore.WPF.Pages.ProductPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:EStore.WPF.Pages     5        N� Title$  ProductPage��5	      .��5      � $��10,10,10,10q�6   
����ح� � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��2��6;   $��10q�6O   .+�5      �� -   5         ��Name$ searchTextBox��5      $	��200��6-   $��0,0,10,0q�69   
�������5   (   �� 5      -   5         ��Name$ clearButton��5      $��Clear��6*   $��75��6:   $��0,0,10,0q�6E   6W   �� 5      -   5        $ 	addButton��5      $	��Add��6(   $��75��66   $��0,0,10,0q�6A   6S   �� 5      -   5        $ 
editButton��5      $��Update��6)   $��75��6:   $��0,0,10,0q�6E   6W   �� 5      -   5        $ deleteButton��5      $��Delete��6+   $��75��6<   6G   5      �� 5    
   -   5         ��Name$ productListView��5       $��1��6,   $��0��69   $��10q�6I    �� SelectionMode$ Extended=�6U    �� View 5!      �� 5"      .P�5#      �� $��
Product ID��6%   	 �� Width$		 100��6d   
 �� DisplayMemberBinding
 69   �� *	ProductId+6d   �� 5$      $��Category Name��6%   $		 100��6s   
 6<   �� *Category.CategoryName+6s   �� 5%      $��Product Name��6%   $		 150��6h   
 6;   �� *ProductName+6h   �� 5&      $��
Unit Price��6%   $		 100��6d   
 69   �� *	UnitPrice+6d   5'      5)      �� 5+   
   $��1��6   $��1��6"   $��5q�62   .+�5,      �� $ 
Horizontal=�6   $
��Left=�62   $��10q�6M   $	��250��6Y   .+�5-      �� $��
Product ID��6   $	��100��6-   $
��Left=�69   $��Center=�6T   �� 5.      -   5        $ productIdTextBox��5.      ${�False��65   $	��150��6G    �� 
IsReadOnly$
 True��6S   $��Right=�6e   $��Center=�6�   5/      �� 50      $ 
Horizontal=�6   $
��Left=�62   $��10q�6M   $	��250��6Y   .+�51      �� $��Category Name��6   $	��100��61   $
��Left=�6=   $��Center=�6X   �� 52      -   5         ��Name$ categoryComboBox��52       �� DisplayMemberPath$ CategoryName��65    �� SelectedValuePath$ 
CategoryId��6V   $	��150��6v   $��Right=�6�   $��Center=�6�   53      �� 54      $ 
Horizontal=�6   $
��Left=�62   $��10q�6M   $	��250��6Y   .+�55      �� $��Product Name��6   $	��100��61   $
��Left=�6=   $��Center=�6X   �� 56      -	   5        $ productNameTextBox��56      $	��150��66   $��Right=�6B   $��Center=�6^   57      �� 58      $ 
Horizontal=�6   $
��Left=�62   $��10q�6M   $	��250��6Y   .+�59      �� $��
Unit Price��6   $	��100��6.   $
��Left=�6:   $��Center=�6U   �� 5:      -
   5        $ unitPriceTextBox��5:      $	��150��64   $��Right=�6@   $��Center=�6\   5;      5<      5>      5?      