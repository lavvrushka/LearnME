using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Converters
{
    public class VerticalOffsetToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double verticalOffset && parameter is int index && index >= 0)
            {
                double offset = verticalOffset * index; // Вычисляем смещение
                return new Thickness(0, offset, 0, 0); // Применяем смещение только по вертикали
            }

            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
