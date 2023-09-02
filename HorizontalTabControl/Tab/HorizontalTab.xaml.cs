using HorizontalTabControl.Collections;
using HorizontalTabControl.Interfaces;
using HorizontalTabControl.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HorizontalTabControl.Tab
{
    /// <summary>
    /// Interaction logic for HorizontalTab.xaml
    /// </summary>
    public partial class HorizontalTab : TabControl, INotifyPropertyChanged
    {

        #region Properties, Feilds and Constructor

        private SolidColorBrush m_TabFrameColorBrush;

        public SolidColorBrush TabFrameColorBrush
        {
            get
            {
                return m_TabFrameColorBrush;
            }
            set
            {
                m_TabFrameColorBrush = value;
                OnPropertyChanged("TabFrameColorBrush");
            }
        }

        public HorizontalTab()
        {
            InitializeComponent();
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

        #region Dependency Properties , Callback Method and Properties

        public static readonly DependencyProperty TabItemsProperty =
            DependencyProperty.Register("TabItems", typeof(BasicItemCollection<IBasicItem>), typeof(HorizontalTab), new UIPropertyMetadata(null, OnTabItemsPropertyChanged));

        private static void OnTabItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var horizonTab = d as HorizontalTab;
            if (horizonTab != null)
            {
                var tabData = e.NewValue as BasicItemCollection<IBasicItem>;
                if (tabData != null)
                {
                    horizonTab.ItemsSource = tabData;
                }
            }
        }

        public BasicItemCollection<IBasicItem> TabItems
        {
            get
            {
                return (BasicItemCollection<IBasicItem>)GetValue(TabItemsProperty);
            }
            set
            {
                SetValue(TabItemsProperty, value);
            }
        }

        public static readonly DependencyProperty TabFrameColorProperty =
            DependencyProperty.Register("TabFrameColor", typeof(SolidColorBrush), typeof(HorizontalTab), new PropertyMetadata(null, OnTabFrameColorChanged));

        private static void OnTabFrameColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var horizontalTab = d as HorizontalTab;
            if (horizontalTab != null)
            {
                var newBrush = (SolidColorBrush)e.NewValue;

                horizontalTab.TabFrameColorBrush = newBrush;
            }
        }

        public SolidColorBrush TabFrameColor
        {
            get
            {
                return (SolidColorBrush)GetValue(TabFrameColorProperty);
            }
            set
            {
                SetValue(TabFrameColorProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("HorizontalTabSelectedItem", typeof(IBasicItem), typeof(HorizontalTab), new UIPropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var horizonTab = d as HorizontalTab;
            if (horizonTab != null)
            {
                var selectedItem = e.NewValue as IBasicItem;
                if (selectedItem != null)
                {
                    horizonTab.SelectedItem = selectedItem;
                }
            }
        }

        public IBasicItem HorizontalTabSelectedItem
        {
            get
            {
                return (IBasicItem)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        public static event EventHandler<IBasicItem> OnTabItemSelected;

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            if (SelectedItem is IBasicItem selectedBasicItem)
            {
                OnTabItemSelected?.Invoke(this, selectedBasicItem);
            }
        }

        #endregion

    }
}
