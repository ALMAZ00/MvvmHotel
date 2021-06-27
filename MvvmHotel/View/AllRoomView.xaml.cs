
using MvvmHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvmHotel.View
{
    /// <summary>
    /// Логика взаимодействия для AllRoomView.xaml
    /// </summary>
    public partial class AllRoomView : UserControl
    {
        public readonly AllRoomsViewModel allRoomsVM = new AllRoomsViewModel();
        public AllRoomView()
        {
            InitializeComponent();
            allRoomsVM = new AllRoomsViewModel();

            this.DataContext = allRoomsVM;
        }
    }
}
