using System.Windows;
using System.Windows.Controls;
using SpaceResume2024.ViewModels;

namespace SpaceResume2024.Views;

/// <summary>
/// Interaction logic for ResumeTextUserControl.xaml
/// </summary>
public partial class ResumeTextUserControl : UserControl
{
    #region Private Fields

    private readonly ResumeTextViewModel _resumeTextViewModel = new();

    #endregion Private Fields

    #region Public Constructors

    public ResumeTextUserControl()
    {
        InitializeComponent();
        DataContext = _resumeTextViewModel;
    }

    #endregion Public Constructors

    #region Private Methods

    private void ProfessionalGoalsTitle_OnLoaded(object sender, RoutedEventArgs e)
    {
    }

    #endregion Private Methods
}