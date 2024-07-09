using System.Globalization;
using System.Windows.Data;

namespace SpaceResume2024.Views.Converters;

public class ResumeTextBodyConverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not List<string> list || list is null || list.Count == 0
            ? "No Body Available"
            : string.Join("\n", list);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}