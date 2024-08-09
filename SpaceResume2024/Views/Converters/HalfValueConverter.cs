using System.Globalization;
using System.Windows.Data;

namespace SpaceResume2024.Views.Converters;

public class HalfValueConverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double d)
            return d / 2;
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}