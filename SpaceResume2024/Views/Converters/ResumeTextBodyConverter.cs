using System.Globalization;
using System.Windows.Data;

namespace SpaceResume2024.Views.Converters;

public class ResumeTextBodyConverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is List<string> list)) return string.Empty;
        return string.Join("\n", list);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}