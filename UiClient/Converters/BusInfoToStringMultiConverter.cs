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
    public class BusInfoToStringMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string busId = values[0].ToString();
            string driverFirstName = (string)values[1];
            string driverLastName = (string)values[2];
            string busType = values[3].ToString();
            string busOccupancy = values[4].ToString();
            List<Line> Lines = (List<Line>)values[5];

            return $"Bus id : {busId}{Environment.NewLine}Driver name : {driverFirstName} {driverLastName}{Environment.NewLine}Bus type : {busType}{Environment.NewLine}" +
                $"Bus occupancy : {busOccupancy}{Environment.NewLine}Lines : {string.Join(", ", Lines)}";

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
