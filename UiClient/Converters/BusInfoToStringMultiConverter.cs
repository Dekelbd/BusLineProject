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
            if (values.Length == 7)
            {
                string busId = values[0].ToString();
                string driverFirstName = values[1].ToString();
                string driverLastName = values[2].ToString();
                string busType = values[3].ToString();
                string busOccupancy = values[4].ToString();
                string busColor = values[5].ToString();
                List<Line> Lines = (List<Line>)values[6];

                return $"Bus id : {busId}{Environment.NewLine}Driver name : {driverFirstName} {driverLastName}{Environment.NewLine}Bus type : {busType}{Environment.NewLine}" +
                    $"Bus occupancy : {busOccupancy}{Environment.NewLine}Color : {busColor}{Environment.NewLine}Lines : {string.Join(", ", Lines)}";
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
