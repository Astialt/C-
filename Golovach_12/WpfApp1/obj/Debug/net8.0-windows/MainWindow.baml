   M S B A M L   `   `   `  ����  WpfApp1     OrderManagement.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$+  %Управление заказами��5   	   $	��500��6%   $	��800��62    � 	Resources 5         ModernButtonStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6*   .�5      ��  � ��
 �����6+   �� 5	       � ��
 �   �6+   �� 5
       � ��$ 5q�6'   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0q�60   5      5      .��5      ]� $��10q�6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   .+�5      �� -   5        $��
Новый��5      #��[  6%   6P   �� 5      -   5        $ ��Редактировать��5      #��[  6-   6X   �� 5      -   5        $��Удалить��5      #��[  6'   6R   5      �� 5   
   $ 
Horizontal=�6   $	��Top=�6.   $��	0,10,0,10q�6C   .+�5      �� $��Статус:��6   $��Center=�6'   $��0,0,5,0q�6B   �� 5      -   5         ��Name$ StatusFilterComboBox��5      $	��150��65   .@�5      �� .��6   Все6$   �� 5      .��6   
Новый6&   �� 5      .��6   ВОбработке6+   �� 5      .��6   Выполнен6)   5       5!      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ OrdersDataGrid��5#         AutoGenerateColumns$ False��6+   	   
IsReadOnly$
	 True��6G   
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+6H     5&      $ Клиент��6%   $ * 6P    65   �� *Client+6P     5'      $ Статус��6%   $	 150 6P    65   �� *Status+6P     5(      $ 
Сумма��6%   $	 100 6O    64   �� *Amount+6O    � ContextMenu 5,      �� 5-      .@�5.      m� -   5        $%��Просмотр деталей��5.      69   m� 5/      -   5        $3��-Сменить статус на 'Новый'��5/      6B   m� 50      -   5        $=��7Сменить статус на 'ВОбработке'��50      6G   m� 51      -	   5        $9��3Сменить статус на 'Выполнен'��51      6E   52      54      55      56      