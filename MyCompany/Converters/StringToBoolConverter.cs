using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyCompany.Converters
{
    public class StringToBoolConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return true;

            string val = value.ToString();
            return string.IsNullOrWhiteSpace(val);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
