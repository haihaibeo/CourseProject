using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page.
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {           
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.MainPage:
                    return new MainPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SectionValueConverter : BaseValueConverter<SectionValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Section)value)
            {
                case Section.Home:
                    return (int)Section.Home;
                case Section.QuickOrder:
                    return (int)Section.QuickOrder;
                case Section.CreatePizza:
                    return (int)Section.CreatePizza;
                case Section.Discount:
                    return (int)Section.Discount;
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
