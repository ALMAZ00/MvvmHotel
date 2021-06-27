using MvvmHotel.View;
using MvvmHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmHotel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();

        public App()
        {
            displayRootRegistry.RegisterWindowType<ClientViewModel, ClientView>();
            displayRootRegistry.RegisterWindowType<RoomViewModel, RoomView>();
            displayRootRegistry.RegisterWindowType<SettlingViewModel, SettlingView>();
        }
    }
}
