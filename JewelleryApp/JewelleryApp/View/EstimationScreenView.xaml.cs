using JewelleryApp.Classes;
using JewelleryApp.ViewModel;
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

namespace JewelleryApp.View
{
    /// <summary>
    /// Interaction logic for EstimationScreenView.xaml
    /// </summary>
    public partial class EstimationScreenView : UserControl
    {

        private EstimationScreenViewModel _estimationScreenViewModel;

        public EstimationScreenView(Users _users)
        {
            InitializeComponent();
            _estimationScreenViewModel = new EstimationScreenViewModel(_users);
            DataContext = _estimationScreenViewModel;
        }
    }
}
