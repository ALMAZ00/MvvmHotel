
using MvvmHotel.Models;
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
    /// Логика взаимодействия для AllSettlingsView.xaml
    /// </summary>
    public partial class AllSettlingsView : UserControl
    {
        private AllSettlingsViewModel viewModel = new AllSettlingsViewModel();
        public AllSettlingsView()
        {
            InitializeComponent();
            viewModel = new AllSettlingsViewModel();

            this.DataContext = viewModel;
        }
    }
}
