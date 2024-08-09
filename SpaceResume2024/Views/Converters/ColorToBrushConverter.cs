using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SpaceResume2024.Views.Converters;

public class ColorToBrushConverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is string colorString
            ? (SolidColorBrush)new BrushConverter().ConvertFromString(colorString)
            : Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}