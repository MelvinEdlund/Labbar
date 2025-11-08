using System;
using System.Globalization;
using System.Windows.Data;

namespace Labb3_Quiz.Converters;


/// Visa "Start Round" knappen när inte rundan är aktiv OCH inte visar resultat.
public class AndBoolConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length >= 2 && 
            values[0] is bool isRoundActive && 
            values[1] is bool showResults)
        {
           
            return (!isRoundActive && !showResults) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }
        return System.Windows.Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

