   M S B A M L   `   `   `  ����  Golovach_17&     OrderManagementDemo.OrdersWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$+  %Управление заказами��5   	   $	��500��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�5   	   ���#F0F0F0 � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value T� X �� Triggers :� RoutedEvent	 �� TargetProperty
 W� From	 W� To g� Duration �� Binding �� Value N� EnterActions	 �� To g� AutoReverse��%�  '        �� 5	   
   "  6   .�5
      ��  �@J�Opacity$ 0Q�6(   �� 5       � z� 5      T� 5      $	 -50Q�6)   5       5      :� 5      $ Loaded��6   .[�5      �� .��5      �� .��5      W� $	 Opacity�6.   
 05        16)   $ 0:0:0.8D�60   W� 5      $,	 &RenderTransform.(TranslateTransform.X)�6.   
 -505        06+   $ 0:0:0.8D�62   5      5      5      �� 5       6   �� *Status+ Отменен69    5      �� 5      .��5       �� .��5!   "   �� $*	 $(Background).(SolidColorBrush.Color)�61    
LightCoral5"   !   $ 0:0:0.5D�61   $
 True��6D   5#      5$      5&      5(      5)      .��5+      � $��10q�6    � RowDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $
��Auto �6   .+�52   
   &   System.Windows.Controls.DataGrid  -   5          Name$ OrdersDataGrid��52      $��0��6+      AutoGenerateColumns$ False��68      CanUserAddRows$ False��53   .      SelectionMode$ Single=�6E   $��0,0,0,10q�6\   ��6   �� *Orders+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Товар��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *	Product+6P     58      $ Кол-во��6%   $	 100 6R    65   �� *
Quantity+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5;      $ Статус��6)   $	 150 69      CellTemplate 5=      �� 5>      .R�5?      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5A   "   A� $��12��6*   $��12��65   $��0,0,5,0q�6A   ��5B   &   �� 5C   *   " A�60   .�5E   .   ��  � ��
 �����6E    5F   .   �� 5G   2    6>   �� *Status+ 
Новый6Y   .a�5H   6   ��  � ��
 � � �6M   5I   3   �� 5J   2    6>   �� *Status+ В обработке6Y   .a�5K   6   ��  � ��
 � ���6M   5L   3   �� 5M   2    6>   �� *Status+ Завершён6Y   .a�5N   6   ��  � ��
 ��  �6M   5O   3   �� 5P   2    6>   �� *Status+ Отменен6Y   .a�5Q   6   ��  � ��
 �  ��6M   5R   3   5T   +   5V   #   �� 5W   "   $��Center=�6D   ��6,   �� *Status+6D   5X      5Y         CellEditingTemplate 5]      �� 5^      .R�5_      �� $��Center=�5a       �� SelectedItem 5_   '   �� *Status+ �� Mode$ TwoWay=���5`      ��   �� RelativeSource  �� ! �� AncestorType
! Window" �� Path$" DataContext.StatusList�5a      5b      5d      5f      �� 5i   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5j      �� -   5        $��Добавить��5j      $	��100��6(   $��5q�64   6?   �� 5k      -   5        $ ��Редактировать��5k      $	��100��6-   $��5q�69   6D   �� 5l      -   5        $��Удалить��5l      $	��100��6'   $��5q�63   6>   5m      5n      5o      