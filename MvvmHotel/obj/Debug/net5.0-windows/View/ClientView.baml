   M S B A M L   `   `   `  ����D  @MvvmHotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MvvmHotel.ViewModelMvvmHotel.ViewModel  5   	       MvvmHotel.View.ClientView   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MvvmHotel.ViewModel     5   	     � Title$  
ClientView��5   	   $	��450��6   $	��800��6)    � DataContext 5
      )   #MvvmHotel.ViewModel.ClientViewModel  5   
   .��5      �� -   5         ��Name$ panel��5      .+�5   
   �� $
��Name��6   6!   �� 5   
   ��6   �� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6\   �� 5   
   $��Surname��6   6$   �� 5   
   ��6   �� *	Surname+$ TwoWay=�$ PropertyChanged=�6_   �� 5   
   $��PassportData��6   6)   �� 5   
    �� 
IsReadOnly 6   �� *IsBlockPassportData+$ OneWay=���5      �� *PassportData+$ TwoWay=�$ PropertyChanged=�6d   �� 5   
   $��PhoneNumber��6   6(   �� 5   
   ��6   �� *PhoneNumber+$ TwoWay=�$ PropertyChanged=�6c   �� 5   
   $��Сохранить��6/   {�6   �� *	IsValid+��5      �� *
SaveClient+62   �� 5    
   $��Удалить��63   {�6   �� *IsOldClient+��5!      �� *DeleteClient+64   5"      5#      