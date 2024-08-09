using SpaceResume2024.ViewModels.EventArgs;
using SpaceResume2024.ViewModels.NASA;
using System.Windows;
using System.Windows.Controls;

namespace SpaceResume2024.Views;

/// <summary>
/// Interaction logic for OrbitalPathControl.xaml
/// </summary>
public partial class OrbitalPathControl : UserControl
{
    #region Public Constructors

    public OrbitalPathControl()
    {
        //this.DataContext = new OrbitalPathControlViewModel(planetViewModelInstance);

        InitializeComponent();
        // Assuming mainWindow is an instance of your MainWindow.
        var mainWindow = Application.Current.MainWindow as MainWindow;
        //if (mainWindow != null)
        //{
        //    mainWindow.OrbitalPathControlLoaded += HandleOrbitalPathControlLoaded;
        //}

        //mainWindow.OrbitalPathControlLoaded += HandleOrbitalPathControlLoaded;
    }

    #endregion Public Constructors

    #region Public Events

    public event EventHandler<PlanetViewModelEventArgs> OrbitalPathControlLoaded;

    #endregion Public Events

    #region Public Methods

    public void PlanetButton_Click(object sender, RoutedEventArgs e)
    {
    }

    #endregion Public Methods

    #region Private Methods

    private void HandleOrbitalPathControlLoaded(object sender, PlanetViewModelEventArgs e)
    {
        DataContext = e.PlanetViewModel;
    }

    private void OrbitalPathControl_Loaded(object sender, RoutedEventArgs e)
    {
        // Assuming OrbitalPathControlViewModel is the DataContext for your OrbitalPathControl
        if (DataContext is OrbitalPathControlViewModel viewModel)
        {
            var planetViewModel = viewModel.PlanetViewModel; // Access the PlanetViewModel property

            // Now, invoke the event
            OrbitalPathControlLoaded?.Invoke(this, new PlanetViewModelEventArgs(planetViewModel));
        }
    }

    #endregion Private Methods
}