   M S B A M L   `   `   `  ����D  @MvvmHotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MvvmHotel.ViewModelMvvmHotel.ViewModel  5   	       MvvmHotel.View.RoomView   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MvvmHotel.ViewModel     5   	     � Title$  RoomView��5   	   $	��450��6   $	��800��6'    � DataContext 5
      '   !MvvmHotel.ViewModel.RoomViewModel  5   
   .��5      �� -   5         ��Name$ panel��5      .+�5   
   �� $��
Номер��60   {�6   �� *	IsOldRoom+6B   �� 5   
    �� 
IsReadOnly$
 True��62   {�6   �� *	IsOldRoom+��5      �� *Number+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6^   �� 5   
   $��Вместимость��6   6(   �� 5   
   ��6   �� *
Capacity+$ TwoWay=�$ PropertyChanged=�6`   �� 5   
   $��Комфортность��6   6)   �� 5   
   -   5         ��Name$ 
comfortsCB��5      ��6'   �� *
Comforts+ �� SelectedItem 5      �� *	Comfort+$ TwoWay=�$ PropertyChanged=�6h   �� 5   
   $��Цена��6   6!   �� 5   
   ��6   �� *Price+$ TwoWay=�$ PropertyChanged=�6]   �� 5   
   $��Сохранить��6/   {�6   �� *	IsValid+��5      �� *
SaveRoom+60   �� 5   
   $��Удалить��61   {�6   �� *	IsOldRoom+��5       �� *
DeleteRoom+62   5!      5"      