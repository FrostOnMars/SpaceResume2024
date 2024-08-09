using Microsoft.Extensions.DependencyInjection;
using SpaceResume2024.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace SpaceResume2024;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region Public Constructors

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
        DataContext = ((App)Application.Current).ServiceProvider.GetRequiredService<MainWindowViewModel>(); //
        viewModel.ScreenWidth = SystemParameters.PrimaryScreenWidth;
        viewModel.ScreenHeight = SystemParameters.PrimaryScreenHeight;
        Loaded += MainWindow_Loaded;
        MouseMove += MouseTracker_OnMouseMove;
    }

    #endregion Public Constructors

    #region Private Methods

    private void OnLoaded_Button(object sender, RoutedEventArgs e)
    {
        //TODO: Implement this method
    }

    #endregion Private Methods

    private void MyListView_OnLoaded(object sender, RoutedEventArgs e)
    {
        _viewModel.GetResumeText();
        ;
    }

    #region Private Fields

    private readonly MainWindowViewModel _viewModel = new();
    private MainWindowViewModel viewModel => DataContext as MainWindowViewModel;

    #endregion Private Fields
}

public partial class MainWindow : Window
{
    //determine how big the screen is (but start with static value - 800 x 800)
    //
    //public event EventHandler<PlanetViewModelEventArgs> OrbitalPathControlLoaded;
    //public void RaiseOrbitalPathControlLoadedEvent(PlanetViewModel viewModel)
    //{
    //    OrbitalPathControlLoaded?.Invoke(this, new PlanetViewModelEventArgs(viewModel));
    //}

    //private void LoopThatBanjoBaby()
    //{
    //    MediaPlayer.Position = TimeSpan.Zero; // Reset the media's position to the start.
    //    MediaPlayer.Play(); // Play the media again.

    //}
    //private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
    //{
    //    LoopThatBanjoBaby();
    //}

    #region Private Methods

    private void Button1_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Button2_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Button3_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Button4_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Button5_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Button6_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Button7_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // Access the ActualHeight and ActualWidth properties of the window to automatically set the
        // grid size
        TheMainWindow.Height = ActualHeight;
        TheMainWindow.Width = ActualWidth;
        //MediaPlayer.Source = new Uri(@"C:\Code\InteractiveResume\InteractiveResume\Resources\Deep Space Banjo.wav", UriKind.Absolute);
        //MediaPlayer.Play();

        // uh oh bad code, shouldn't be calling on other view models from here
        //foreach (var planetViewModel in viewModel.PlanetViewModels)
        //{
        //    RaiseOrbitalPathControlLoadedEvent(planetViewModel);
        //}
    }

    private void MediaPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
        MessageBox.Show($"Media failed to load/play. Error: {e.ErrorException.Message}", "Media Error",
            MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private void MouseTracker_OnMouseMove(object sender, MouseEventArgs e)
    {
        viewModel.UpdateCoordinates(e.GetPosition(this));
    }

    //private void OnClick(object sender, RoutedEventArgs e)
    //{
    //    var planetModels = SqlController.GetAllPlanetModels();
    //    ;

    //}

    private void OnEnter(object sender, DragEventArgs e)
    {
    }

    private void OnLeave(object sender, DragEventArgs e)
    {
    }

    #endregion Private Methods

    #region Sql button commands stored here.

    //var header = SqlController.GetAllResumeHeaders();
    //var education = SqlController.GetAllResumeEducationModels();
    //var skills = SqlController.GetAllResumeSkills();

    #endregion Sql button commands stored here.
}