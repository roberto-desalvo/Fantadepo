using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.MAUI.MVVM.Converters
{
    public class CoachToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Coach coach)
            {
                throw new InvalidOperationException($"Value should be of type {typeof(Coach).FullName}");
            }
            return $"{coach.FirstName} {coach.LastName}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string str)
            {
                throw new InvalidOperationException($"Value should be of type string");
            }
            var list = str.Split(' ');
            return new Coach
            {
                FirstName = list[0].Trim(),
                LastName = list[1].Trim(),
            };
        }
    }
}
