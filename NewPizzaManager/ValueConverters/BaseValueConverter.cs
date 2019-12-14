﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Data;
using System.Windows.Data;
using System.Globalization;

namespace NewPizzaManager
{

    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        private static T _converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
                _converter = new T();
            return _converter;
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

    }
}
