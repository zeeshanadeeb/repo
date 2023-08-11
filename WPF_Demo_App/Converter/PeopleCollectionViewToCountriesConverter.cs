using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace WPF_Demo_App.Converter
{
    public class PeopleCollectionViewToCountriesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollectionView collectionView)
            {
                var countries = collectionView.OfType<PersonData>().Select(person => person.Country).Distinct().ToList();
                countries.Insert(0, "");
                countries.Sort();
                return countries;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
