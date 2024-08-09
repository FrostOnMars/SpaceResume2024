using SpaceResume2024.ViewModels.NASA;

namespace SpaceResume2024.ViewModels.EventArgs;

public class PlanetViewModelEventArgs : System.EventArgs
{
    #region Public Constructors

    public PlanetViewModelEventArgs(PlanetViewModel planetViewModel)
    {
        PlanetViewModel = planetViewModel;
    }

    #endregion Public Constructors

    #region Public Properties

    public PlanetViewModel PlanetViewModel { get; }

    #endregion Public Properties
}