using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UiClient.Converters
{
    public class DriverInfoToStringMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string FirstName = (string)values[0];
            string LastName = (string)values[1];
            string PhoneNumber = (string)values[2];
            string Address = (string)values[3];

            return $"Driver name : {FirstName} {LastName}{Environment.NewLine}Phone number : {PhoneNumber}{Environment.NewLine}Address : {Address}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
