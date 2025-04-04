using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OrderManagement.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool flag && flag) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility vis)
                return vis == Visibility.Visible;
            return false;
        }
    }
}
