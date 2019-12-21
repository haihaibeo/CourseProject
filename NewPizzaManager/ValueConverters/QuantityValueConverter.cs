using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class QuantityValueConverter : BaseValueConverter<QuantityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Quantity)value)
            {
                case Quantity.Один: return 1;
                case Quantity.Два: return 2;
                case Quantity.Три: return 3;
                case Quantity.Четыре: return 4;
                case Quantity.Пять: return 5;
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((int)value)
            {
                case 1: return Quantity.Один;
                case 2: return Quantity.Два;
                case 3: return Quantity.Три;
                case 4: return Quantity.Четыре;
                case 5: return Quantity.Пять;
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
