using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RemoteControlArduino.Converters
{
    public class ConnectingStatusToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string propertyParameter = (string)parameter;
            string propertyValue = (string)value;

            if (propertyValue == "Connect")
            {
                if (propertyParameter == "ComboBoxColor")
                {
                    return Brushes.Black;
                }
                if (propertyParameter == "OutputInfoColor")
                {
                    return Brushes.Black;
                }
                if (propertyParameter == "ConnectButtonColor")
                {
                    return Brushes.YellowGreen;
                }
            }
            else if (propertyValue == "Disconnect")
            {
                if (propertyParameter == "ComboBoxColor")
                {
                    return Brushes.Gray;
                }
                if (propertyParameter == "OutputInfoColor")
                {
                    return Brushes.Green;
                }
                if (propertyParameter == "ConnectButtonColor")
                {
                    return Brushes.Orange;
                }
            }
            else if (propertyValue == "Error")
            {
                if (propertyParameter == "OutputInfoColor")
                {
                    return Brushes.Red;
                }
            }
            else if (propertyParameter == "StatusConditioner")
            {
                if (propertyValue == "OFF")
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.Green;
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
