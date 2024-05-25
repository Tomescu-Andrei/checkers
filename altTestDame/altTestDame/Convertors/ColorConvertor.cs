using altTestDame.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace altTestDame.Converters
{
    internal class ColorConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is colorpiece color)
            {
                switch (color)
                {
                    case colorpiece.Red:
                        return Brushes.Red;
                    case colorpiece.Black:
                        return Brushes.Black;
                    case colorpiece.Green:
                        return Brushes.Green;
                    default:
                        return Brushes.Red; 
                }
            }
            return Brushes.Red; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is colorpiece color)
            {
                switch (color)
                {
                    case colorpiece.Red:
                        return Brushes.Red;
                    case colorpiece.Black:
                        return Brushes.Black;
                    case colorpiece.Green:
                        return Brushes.Green;
                    default:
                        return Brushes.Red; 
                }
            }
            return Brushes.Red;
        }
    }
}
