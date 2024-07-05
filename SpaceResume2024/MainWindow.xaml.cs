using SpaceResume2024.ViewModels;
using System.Windows;

namespace SpaceResume2024;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region Private Fields

    private readonly MainWindowViewModel _viewModel = new();

    #endregion Private Fields

    #region Public Constructors

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }

    #endregion Public Constructors

    #region Private Methods

    private void OnLoaded_Button(object sender, RoutedEventArgs e)
    {
    }

    #endregion Private Methods

    private void MyListView_OnLoaded(object sender, RoutedEventArgs e)
    {
        _viewModel.GetResumeText();
        ;
    }
}