   M S B A M L   `   `   `  ����  
MailSender$    MailSender.Views.SaveEmailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5      �� *Main+   Locator �� Source# [  .��5	      �   6   �� *CurrentEmail+ � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $��20 �6   �� 5&      $
��Auto �6    � ColumnDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6   .+�5,   
   �� $��0��6   $��0��6$   $	��id:��61   $��Right=�5-      �� 5.   
   $��0��6   $��1��6$   $��Address:��61   $��Right=�5/      �� 50   
   $��0��6   $��2��6$   $��Name:��61   $��Right=�51      �� 52   
   $��1��6   $��0��6"   ��6/   �� *Id+�� 53   
   $��1��6   $��1��6"   ��6/   �� *Email+�� 54   
   $��1��6   $��2��6"   ��6/   �� *Name+�� 55   
   $��4��6   $��0��6   $��2��6.   $��Сохранить��56      $��Center=�5:      $
��30,0q�6.   ��57      �� *DataContext.SaveEmailCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL���59      �� 5:   .   5;      5<      