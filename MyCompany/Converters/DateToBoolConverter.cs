using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyCompany.Converters
{
    public class DateToBoolConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return false;

            DateTime val = (DateTime)value;
            return val == DateTime.MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.MinValue;
        }
    }
}
