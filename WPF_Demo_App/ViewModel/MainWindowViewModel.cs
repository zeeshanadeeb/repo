using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WPF_Demo_App.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<PersonData> _people;
        public ObservableCollection<PersonData> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                OnPropertyChanged("People");
            }
        }

        private string _selectedCountry;
        public string SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                FilterPeople();
                OnPropertyChanged("SelectedCountry");
            }
        }

        private ICollectionView _peopleView;
        public ICollectionView PeopleView
        {
            get { return _peopleView; }
            set
            {
                _peopleView = value;
                OnPropertyChanged("PeopleView");
            }
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            LoadData();
            PeopleView = CollectionViewSource.GetDefaultView(People);
            PeopleView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            PeopleView.SortDescriptions.Add(new SortDescription("Country", ListSortDirection.Ascending));
        }

        #endregion

        #region Methods Loading , Sorting , Filter

        private void LoadData()
        {
            using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\PersonsDemo.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                People = new ObservableCollection<PersonData>(csv.GetRecords<PersonData>());
            }
        }

        private void FilterPeople()
        {
            if (string.IsNullOrEmpty(SelectedCountry))
            {
                PeopleView.Filter = null;
            }
            else
            {
                PeopleView.Filter = obj => ((PersonData)obj).Country == SelectedCountry;
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
