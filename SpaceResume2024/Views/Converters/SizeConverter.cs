﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SpaceResume2024.Views.Converters;

public class SizeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double d)
            return new Size(d, d);
        return Size.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}