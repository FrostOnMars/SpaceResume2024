using SpaceResume2024.ViewModels.NASA;

namespace SpaceResume2024.ViewModels.EventArgs;

public class PlanetViewModelEventArgs : System.EventArgs
{
    public PlanetViewModel PlanetViewModel { get; }

    public PlanetViewModelEventArgs(PlanetViewModel planetViewModel)
    {
        PlanetViewModel = planetViewModel;
    }
}