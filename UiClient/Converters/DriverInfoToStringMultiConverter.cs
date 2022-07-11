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
            if (values.Length == 4)
            {
                string FirstName = values[0].ToString();
                string LastName = values[1].ToString();
                string PhoneNumber = values[2].ToString();
                string Address = values[3].ToString();

                return $"Driver name : {FirstName} {LastName}{Environment.NewLine}" +
                        $"Phone number : {PhoneNumber}{Environment.NewLine}Address : {Address}";
            }
            return null;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
