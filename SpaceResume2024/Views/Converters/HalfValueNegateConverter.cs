using System.Globalization;
using System.Windows.Data;

namespace SpaceResume2024.Views.Converters;

public class HalfValueNegateConverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double d) return -(d / 2.0) + 400; // Add 400 offset for centering
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}