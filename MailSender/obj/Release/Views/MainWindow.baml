   M S B A M L   `   `   `  ���� E  AMailSender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MailSender
MailSender  F BTabSwitcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:TabSwitcher;assembly=TabSwitcherTabSwitcher 3clr-namespace:MailSender.ViewsMailSender.Views      MailSender.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:MailSender     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  @TabSwitcher.clr-namespace:TabSwitcher;assembly=TabSwitcher  )viewclr-namespace:MailSender.Views  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $��MainWindowForm��$	��450��$	��800��  � DataContext  �� *Main+   Locator �� Source# [  .��]� .+�o� $	��Top=�.@�m� $
��File��.@�m� $
��Exit�� m� Command (   "MailSender.ApplicationCloseCommand  $  TabSwitcher.TabSwitcherControl  -   $��Bottom=��� -   $��MainTabControl��.@��� $��Рассылка��.��]� .+�`� $	��Top=� � 	Resources   PluseGeometry @� RadiusX @� RadiusY @� Center  MinusGeometry  ComfirmGeometry��%�   &	       &	 L     &	 �     � .��@� $ 8Q�$ 8Q�$	 9,9&�B� $��m9,9 m0,-5 v10 m-5,-5 h10C�� .��@� $ 8Q�$ 8Q�$	 9,9&�B� $��m9,9 m-5,0 h10C�� .��@� $ 8Q�$ 8Q�$	 9,9&�B� $��m8,13 l-3,-3 m3,3 l5,-7C�.�c� .@��� $��Отправитель:���� -   $��cbSenderSelect��$	��150��   MailSender.Resources   SendersDictionary#��Z  �� SelectedIndex$ 0��	 �� SelectedItem	 �� *
CurSenders+���� .R��� ���� *Key+�� 
 � ToolTip$-
 'Добавить отправителя��.��F� $��18��$��18��
����  �$��2��#��[ �� $7
 1Редактировать отправителя��.��F� $��18��$��18��
����·�$��2��#��[ �� $+
 %Удалить отправителя��.��F� $��18��$��18��
���  ��$��2��#��[ c� .@��� .��Планировщик:�� -   $(
 "Перейти к рассылке��.���� $��/src/clock.png��$��15��$��2q�c�  c� Band$ 1��.@��� .��Сервер:�� -   $��ServerSelector��$	��150��$ 0������ *SmtpServers+ �� SelectedValue �� *SelectedServer+����  �� DataType   MailSender.SmtpServerInfo"  .R��� ���� *Server+�� $#
 Добавить сервер��.��F� $��18��$��18��
����  �$��2��#��[ �� $-
 'Редактировать сервер��.��F� $��18��$��18��
����·�$��2��#��[ �� $+
 %Удалить отправителя������ *DeleteServerCommand+���� *SelectedValue+ �� ElementName$ ServerSelector��.��F� $��18��$��18��
���  ��$��2��#��[ c� $ 1��.@��� .��" Список адресатов:�� -   $��AddAddressButton��$'
 !Добавить адресата��.��F� $��18��$��18��
����  �$��2��#��[ �� $1
 +Редактировать адресата��.��F� $��18��$��18��
����·�$��2��#��[ �� $%
 Удалить адресата��.��F� $��18��$��18��
���  ��$��2��#��[ $   MailSender.Views.SaveEmailView      MailSender.Views.EmailInfo  �� -   $��
tabPlanner��$��Планировщик��.���  � ColumnDefinitions �� $��44.506 ��� $��150.494 ��� .+��� $��0��$��3q�$��2��.+��� $#��Добавить письмо������ *
BtnAddMail+�� -	    ��Name$ 
lstvwMails��$	��100������ *	SendMails+�� $	��0,3q�.����  �� Orientation$ 
Horizontal=�.+��� $��15��$'��!pack://application:/src/clock.png��$��0,0,4,0q��� $ ��Запланировать���� $%��Отправить сейчас���� $)��#Редактор сообщений��.���� 