using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SpaceResume2024.Views.Converters;

public class ImageSourceConverter : IValueConverter
{
    #region Public Methods

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string path && !string.IsNullOrEmpty(path))
        {
            return new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}