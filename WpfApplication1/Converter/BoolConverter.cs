using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication1
{
    class BoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0].ToString().ToLower().Equals("true") && values[0].ToString().ToLower().Equals("mohsin"))
            {
                return "Checked";
            }
            return "Not Checked";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2] { "", ""};
        }
    }
   
}
