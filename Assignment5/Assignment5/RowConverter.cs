using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Assignment5
{
    //We use this class to show vehicles that are older than 10 years in a different color in our data grid.
    public class RowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Appointment)
            {
                if(((Appointment)value).CustVehicleYearOfMake < 2011)
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.White;
                }
            } else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
