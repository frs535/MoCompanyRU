using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyCompany.Converters
{
    public class DateToStringMonthConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? val = (DateTime)value;
            if (val == null)
                return string.Empty;

            return val.Value.ToString("MMMM yy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.MinValue;
        }
    }
}
