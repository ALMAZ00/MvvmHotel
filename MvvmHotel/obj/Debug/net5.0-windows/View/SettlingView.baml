   M S B A M L   `   `   `  ����D  @MvvmHotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MvvmHotel.ViewModelMvvmHotel.ViewModel  5   	   !    MvvmHotel.View.SettlingView   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MvvmHotel.ViewModel     5   	     � Title$  SettlingView��5   	   $	��450��6   $	��800��6+    � DataContext 5      +   %MvvmHotel.ViewModel.SettlingViewModel  5   
   .��5      �� -   5         ��Name$ panel��5      .+�5   
   �� $��Клиент:��6   6$   �� 5   
   -   5         ��Name$ clientCB��5      ��6%   �� *
AllClients+ �� SelectedItem 5      �� *ClientNameAndSurname+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6u   �� 5   
   $��Номер:��6   6#   �� 5   
   -   5        $ roomCB��5      ��6#   �� *
AllRooms+$ PropertyChanged=� 5      �� *
RoomNumber+$ TwoWay=�$ PropertyChanged=�6k   �� 5   
   $"��Дата заселения:��6   6,   (  "System.Windows.Controls.DatePicker  5   
      SelectedDate 6   �� *	EntryDate+$ TwoWay=�$ PropertyChanged=�6l   �� 5   
   $��Сохранить��6/   {�6   �� *	IsValid+��5      �� *SaveSettling+64   5      5      