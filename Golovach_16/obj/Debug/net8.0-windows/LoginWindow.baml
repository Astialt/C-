   M S B A M L   `   `   `  ����F  BGolovach_16, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:OrderManagement.ViewModelsOrderManagement.ViewModels  5   	   '    !OrderManagement.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7vm(clr-namespace:OrderManagement.ViewModels     5   	     � Title$  Авторизация��5   	   $	��250��6   $	��350��6*    � WindowStartupLocation$ CenterOwner=�5   	   ���#ECEFF1 � DataContext 5      .   (OrderManagement.ViewModels.AuthViewModel  5	   
   .��5      � $��	0,10,0,-6q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��
Логин��6   $��22(�6!   $
��Bold"�6/   $��Center=�6A   $��0,0,0,20q�6^   �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $&�� Имя пользователя:��6   �� 5      $	��250��6=   $��5q�6I   ��6   �� *
Username+ �� Mode$ TwoWay=�6I   5      �� 5   
   $��2��6   $��0,0,0,10q�6"   .+�5      �� $��Пароль:��6   G� 5      -   5         G�Name$ PasswordBox��5      $	��250��6/   $��5q�6;   6G   5      �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5      �� $��Вход��6      PrimaryButtonStyle#��[  6$   $	��100��6P   ��6\   �� *LoginCommand+�� 5      $��Регистрация��6   #��[  6+   $	��120��6W   ��6c   �� *RegisterCommand+5      5      5       