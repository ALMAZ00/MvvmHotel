   M S B A M L   `   `   `  ����D  @MvvmHotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MvvmHotel.ViewMvvmHotel.View  5      9!clr-namespace:MvvmHotel.ViewModelMvvmHotel.ViewModel  5      %    MvvmHotel.View.AllSettlingsView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MvvmHotel.View     5      7	viewmodel!clr-namespace:MvvmHotel.ViewModel     5      .��5
      �� .+�5   
   �� $��30��6   $ ��Все заселения:��6   67   �� 5   
   -   5        $��filter��5      $��30��6   6.   �� 5   
   $��30��6   ��6   �� *
FilterList+��6<   �� *Text+  �� ElementName$  filter��.��6r   Отфильтровать6�   �� 5   
   $	��250��6   $
��Auto=�6$   $
��Auto=�6G   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ allSettlingDg��5      $
��True��6.   $
��Auto=�6S   $
��Auto=�5         AutoGenerateColumns$ False��6E      CanUserAddRows$ False��5         CanUserReorderColumns$ False��6*      CanUserDeleteRows$ False��6H   ��5      �� *AllSettlings+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО Клиента��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *ClientNameAndSurname+	 �� Mode$	 OneWay=�6w     5      $ Номер комнаты��6)    6@   �� *
RoomNumber+$	 OneWay=�6n     5      $! Дата заселения��6)    6A   �� *	EntryDate+$	 OneWay=�6n     5      $! Дата выселеняи��6)    6A   �� *ReleaseDate+$	 OneWay=�6p   4  .System.Windows.Controls.DataGridTemplateColumn  5      
   CellTemplate
 5      �� 5      .R�5   "   �� $��Удалить��6)   ��5   )   �� *DataContext.DeleteSettling+$  allSettlingDg����5   )   �� *SelectedItem+$  allSettlingDg��6p   5      5         5!      
 5"      �� 5#      .R�5$   "   �� $'��!Закрыть заселение��6N   {�6)   �� *IsOpenSettling+��5%   )   �� *DataContext.ReleaseSettling+$  allSettlingDg����5&   )   �� *SelectedItem+$  allSettlingDg��6p   5'      5)      5+      5,      �� 5.   
   $��30��6   $'��!Создать заселение��6   ��69   �� *CreateSettling+6^   5/      50      