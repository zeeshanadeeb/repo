using HorizontalTabControl.Collections;
using HorizontalTabControl.Interfaces;
using HorizontalTabControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorizontalTabControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel();
            DataContext = _mainWindowViewModel;
        }

        private void TabControlScroller_Loaded(object sender, RoutedEventArgs e)
        {
            //Another way around for scrolling tab left or right, But we need the object of ScrollViewer before we use it in ICommands
            _mainWindowViewModel.scrollViewer = sender as ScrollViewer;
        }

    }
}
