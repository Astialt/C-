   M S B A M L   `   `   `  ����  Golovach_16-    'OrderManagement.Views.CreateOrderWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Добавить заказ��5   	   $	��300��6    $	��400��6-    � WindowStartupLocation$ CenterOwner=�5   	   ���#ECEFF1.��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   �� $��Продукт:��6   $��0��6$   $��0��61   $��Center=�6A   $��5q�6\   �� 5   
   -   5         ��Name$ ProductTextBox��5      $��0��6*   $��1��67   $��5q�6G   $��5q�6R   �� 5   
   $��Количество:��6   $��1��6'   $��0��64   $��Center=�6D   $��5q�6_   �� 5   
   -   5        $ QuantityTextBox��5      $��1��6+   $��1��68   $��5q�6H   $��5q�6S   �� 5   
   $��Статус:��6   $��2��6#   $��0��60   $��Center=�6@   $��5q�6[   �� 5   
   -   5         ��Name$ StatusComboBox��5      $��2��6+   $��1��68   $��5q�6H   $��5q�6S    �� SelectedIndex$ 0��6_   .@�5      �� $��Ожидает��6   �� 5      $��Обработан��6   �� 5       $��Отменён��6   5!      �� 5$   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��10q�6k   .+�5%      �� -   5        $��Добавить��5%      $	��100��6(      PrimaryButtonStyle#��[  6L   �� 5&      -   5        $��Отмена��5&      $	��100��6&   #��[  6M   $��5,0,0,0q�6y   5'      5(      5)      