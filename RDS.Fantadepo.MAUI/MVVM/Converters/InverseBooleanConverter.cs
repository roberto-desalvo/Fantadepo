﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.MVVM.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is not bool bValue)
            {
                throw new InvalidOperationException("Value should be a boolean type");
            }
            return !bValue;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not bool bValue)
            {
                throw new InvalidOperationException("Value should be a boolean type");
            }
            return !bValue;
        }
    }
}
