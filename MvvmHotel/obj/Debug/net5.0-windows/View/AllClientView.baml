   M S B A M L   `   `   `  ����D  @MvvmHotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MvvmHotel.ViewMvvmHotel.View  5      9!clr-namespace:MvvmHotel.ViewModelMvvmHotel.ViewModel  5      "    MvvmHotel.View.AllClientView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MvvmHotel.View     5      7	viewmodel!clr-namespace:MvvmHotel.ViewModel     5      .��5	      �� .+�5
   
   �� $��30��6   $��Все клиенты:��6   65   �� 5   
   -   5        $��filter��5      $��30��6   6.   �� 5   
   $��30��6   ��6   �� *
FilterList+��6<   �� *Text+  �� ElementName$  filter��.��6r   Отфильтровать6�   �� 5   
   $	��250��6   $
��Auto=�6$   $
��Auto=�6G   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ allClientDg��5      $
��True��6,   $
��Auto=�6Q   $
��Auto=�5         AutoGenerateColumns$ False��6E      CanUserAddRows$ False��5         CanUserReorderColumns$ False��6*      CanUserDeleteRows$ False��6H   ��5      �� *
AllClients+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Name+	 �� Mode$	 OneWay=�6^     5      $ Фамилия��6)    6:   �� *	Surname+$	 OneWay=�6e     5      $ Пасспорт��6)    6;   �� *PassportData+$	 OneWay=�6k     5      $! Номер телефона��6)    6A   �� *PhoneNumber+$	 OneWay=�6p   4  .System.Windows.Controls.DataGridTemplateColumn  5      
   CellTemplate
 5      �� 5      .R�5   "   �� $��Показать��6)   ��6<   �� *DataContext.ShowClient+$  allClientDg����5   )   �� *SelectedItem+$  allClientDg��6n   5      5      5       5!      �� 5$   
   $��30��6   $#��Создать клиента��6   ��67   �� *
ShowClient+6X   5%      5&      