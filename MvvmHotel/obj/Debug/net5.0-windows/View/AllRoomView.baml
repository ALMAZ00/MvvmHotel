   M S B A M L   `   `   `  ����D  @MvvmHotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MvvmHotel.ViewMvvmHotel.View  5      9!clr-namespace:MvvmHotel.ViewModelMvvmHotel.ViewModel  5           MvvmHotel.View.AllRoomView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MvvmHotel.View     5      7	viewmodel!clr-namespace:MvvmHotel.ViewModel     5      .��5	      �� .+�5
   
   �� $��30��6   $��Все номера:��6   64   �� 5   
   $	��250��6   $
��Auto=�6$   $
��Auto=�6G   .��5      &   System.Windows.Controls.DataGrid  -   5           Name$  
allRoomsDg��5      $
��True��6,   $
��Auto=�6Q   $
��Auto=�5         AutoGenerateColumns$ False��6E      CanUserAddRows$ False��5         CanUserReorderColumns$ False��6*      CanUserDeleteRows$ False��6H   ��5      �� *
AllRooms+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Number+ �� Mode$ OneWay=�6b     5      $ Вместимость��6)    6>   �� *
Capacity+$ OneWay=�6j     5      $ Комфортность��6)    6?   �� *	Comfort+$ OneWay=�6j     5      $ Цена��6)    67   �� *Price+$ OneWay=�6`   4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5   "   �� $��Показать��6)   ��6<   �� *DataContext.ShowRoom+
 �� ElementName$
 
allRoomsDg����5   )   �� *SelectedItem+$
 
allRoomsDg��6m   5      5      5      5      �� 5!   
   $��30��6   $��Создать номер��6   ��65   �� *
ShowRoom+6T   5"      5#      