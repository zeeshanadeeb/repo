using HorizontalTabControl.Collections;
using HorizontalTabControl.Commands;
using HorizontalTabControl.Interfaces;
using HorizontalTabControl.Tab;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace HorizontalTabControl.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private BasicItemCollection<IBasicItem> m_TabItemsCollection = new BasicItemCollection<IBasicItem>();
        private IBasicItem m_SelectedTabItem;
        private Visibility m_ScrollLeftButtonVisibility;
        private Visibility m_ScrollRightButtonVisibility;

        private double m_scrollViewerHorizontalOffset;

        public ScrollViewer scrollViewer { get; set; }

        #endregion

        #region Properties

        public BasicItemCollection<IBasicItem> TabItemsCollection
        {
            get
            {
                return m_TabItemsCollection;
            }
            set
            {
                m_TabItemsCollection = value;
                OnPropertyChanged("TabItemsCollection");
            }
        }            

        public IBasicItem SelectedTabItem
        {
            get
            {
                return m_SelectedTabItem;
            }
            set
            {
                m_SelectedTabItem = value;
                OnPropertyChanged("SelectedTabItem");
            }
        }
        
        public Visibility ScrollLeftButtonVisibility
        {
            get
            {
                return m_ScrollLeftButtonVisibility;
            }
            set
            {
                m_ScrollLeftButtonVisibility = value;
                OnPropertyChanged("m_ScrollLeftButtonVisibility");
            }
        }

        public Visibility ScrollRightButtonVisibility
        {
            get
            {
                return m_ScrollRightButtonVisibility;
            }
            set
            {
                m_ScrollRightButtonVisibility = value;
                OnPropertyChanged("ScrollRightButtonVisibility");
            }
        }

        #endregion

        #region ICommands

        public ICommand ScrollRightCommand { get; private set; }
        public ICommand ScrollLeftCommand { get; private set; }
        public int SelectedTabIndex { get; private set; }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {

            ScrollRightCommand = new RelayCommand(ExecuteScrollRight, CanExecuteScrollRight);
            ScrollLeftCommand = new RelayCommand(ExecuteScrollLeft, CanExecuteScrollLeft);

            // Create a collection and add the tab items          
            AddTabItem("1", "Tab 1", "TabIconKey 1");
            AddTabItem("2", "Tab 2", "TabIconKey 2");
            AddTabItem("3", "Tab 3", "TabIconKey 3");
            AddTabItem("4", "Tab 4", "TabIconKey 4");
            AddTabItem("5", "Tab 5", "TabIconKey 5");
            AddTabItem("6", "Tab 6", "TabIconKey 6");
            AddTabItem("7", "Tab 7", "TabIconKey 7");
            AddTabItem("8", "Tab 8", "TabIconKey 8");
            AddTabItem("9", "Tab 9", "TabIconKey 9");

            ScrollLeftButtonVisibility = Visibility.Collapsed;
            ScrollRightButtonVisibility = Visibility.Visible;

            SelectedTabItem = TabItemsCollection[0];

            HorizontalTab.OnTabItemSelected += HorizontalTabControl_OnTabItemSelected;
        }

        #endregion

        #region ICommands Methods

        private void ExecuteScrollRight(object obj)
        {
            double scrollAmount = 50;
            double maxOffset = scrollViewer.ScrollableWidth;
            double newOffset = m_scrollViewerHorizontalOffset + scrollAmount;

            if (newOffset > maxOffset)
            {
                newOffset = maxOffset;
                ScrollRightButtonVisibility = Visibility.Collapsed;
                OnPropertyChanged("ScrollRightButtonVisibility");
            }

            if (newOffset > 50)
            {
                ScrollLeftButtonVisibility = Visibility.Visible;
                OnPropertyChanged("ScrollLeftButtonVisibility");
            }

            m_scrollViewerHorizontalOffset = newOffset;
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToHorizontalOffset(newOffset);
            }

        }

        private bool CanExecuteScrollRight(object arg)
        {
            return true;
        }

        private void ExecuteScrollLeft(object obj)
        {
            double scrollAmount = 50; 
            double newOffset = m_scrollViewerHorizontalOffset - scrollAmount;
            if (newOffset < 0)
            {
                newOffset = 0;
                ScrollLeftButtonVisibility = Visibility.Collapsed;
                OnPropertyChanged("ScrollLeftButtonVisibility");
            }
            else
            {
                ScrollRightButtonVisibility = Visibility.Visible;
                OnPropertyChanged("ScrollRightButtonVisibility");
            }

            m_scrollViewerHorizontalOffset = newOffset;
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToHorizontalOffset(newOffset);
            }
        }

        private bool CanExecuteScrollLeft(object arg)
        {
            return true;
        }

        #endregion

        #region Methods

        public void AddTabItem(object id, string name, string iconKey)
        {
            var newItem = new BasicItem
            {
                Id = id,
                Name = name,
                IconKey = iconKey
            };

            TabItemsCollection.Add(newItem);
        }

        private void HorizontalTabControl_OnTabItemSelected(object sender, IBasicItem e)
        {
            SelectedTabItem = e;
        }

        #endregion

        #region Property Change Event

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion
    }
}
