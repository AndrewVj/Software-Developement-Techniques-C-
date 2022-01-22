using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FinalProject
{
    //We use this class to show Patients who are older than 65 years in a different color in our data grid.
    public class RowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Appointment)
            {
                Appointment appointment = (Appointment)value;

                if (appointment.Patient.Age > 65 )
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.White;
                }
            }
            else
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
