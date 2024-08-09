using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SpaceResume2024.Views.Converters;

public class GeometryConverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value as PathGeometry;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}