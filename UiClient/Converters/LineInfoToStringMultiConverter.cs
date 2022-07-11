using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model.Interfaces;

namespace UiClient.Converters
{
    public class LineInfoToStringMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                string LineName = values[0].ToString();
                List<Station> stations = (List<Station>)values[1];

                return $"Line Name : {LineName}{Environment.NewLine}" +
                    $"Stations : {string.Join(", ", stations)}";
            }
            return null;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
