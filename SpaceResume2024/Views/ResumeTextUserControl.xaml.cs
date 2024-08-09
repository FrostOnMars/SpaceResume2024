using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SpaceResume2024.ViewModels;

namespace SpaceResume2024.Views;

/// <summary>
///     Interaction logic for ResumeTextUserControl.xaml
/// </summary>
public partial class ResumeTextUserControl : UserControl
{
    #region Public Constructors

    public ResumeTextUserControl()
    {
        InitializeComponent();
        //DataContext = _resumeTextViewModel;
        _resumeInfoChanged += OnResumeInfoChanged;
    }

    #endregion Public Constructors

    #region Private Fields

    private EventHandler _resumeInfoChanged;
    private ResumeTextViewModel _resumeTextViewModel;

    #endregion Private Fields

    #region Private Methods

    private static double CalculateHeight(IEnumerable<string?>? lines, double fontSize, double maxWidth)
    {
        double totalHeight = 0;
        foreach (var formattedText in lines.Select(line => new FormattedText(
                     line,
                     CultureInfo.CurrentCulture,
                     FlowDirection.LeftToRight,
                     new Typeface("Segoe UI"),
                     fontSize,
                     Brushes.Black,
                     new NumberSubstitution(),
                     1)))
        {
            formattedText.MaxTextWidth = maxWidth;
            totalHeight += formattedText.Height;
        }

        return totalHeight;
    }

    private void AdjustHeights()
    {
        if (DataContext is not ResumeTextViewModel viewModel) return;
        var titleHeight = CalculateHeight(new List<string?> { viewModel.ResumeInfo?.Title },
            ProfessionalGoalsTitle.FontSize, ProfessionalGoalsTitle.ActualWidth);
        var bodyHeight = CalculateHeight(viewModel.ResumeInfo?.Body, ProfessionalGoalsBody.FontSize,
            ProfessionalGoalsBody.ActualWidth);

        ProfessionalGoalsTitle.Height = titleHeight;
        ProfessionalGoalsBody.Height = bodyHeight;
    }

    private void OnResumeInfoChanged(object? sender, EventArgs e)
    {
    }

    private void ProfessionalGoalsTitle_OnLoaded(object sender, RoutedEventArgs e)
    {
        AdjustHeights();
    }

    private void ResumeTextUserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        AdjustHeights();
    }

    #endregion Private Methods
}