using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UiClient.Converters
{
    public class StationInfoToStringMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string Name = (string)values[0];
            string Latitude = values[1].ToString();
            string Longitude = values[2].ToString();

            return $"Station name : {Name}{Environment.NewLine}Latitude : {Latitude}{Environment.NewLine}Longitude : {Longitude}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
