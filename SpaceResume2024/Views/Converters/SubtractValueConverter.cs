﻿using System.Globalization;
using System.Windows.Data;

namespace SpaceResume2024.Views.Converters;

public class SubtractValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double doubleValue && parameter is string stringParameter && double.TryParse(stringParameter, out var subtractValue))
        {
            return doubleValue - subtractValue;
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}