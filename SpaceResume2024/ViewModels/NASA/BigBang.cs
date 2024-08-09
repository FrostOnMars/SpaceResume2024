using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models.PlanetModels;

namespace SpaceResume2024.ViewModels.NASA;

public sealed class BigBang : ObservableObject
{
    #region Private Constructors

    private BigBang()
    {
    }

    #endregion Private Constructors

    //This class initializes the "Big Bang" and all the planets in it.
    //It is a singleton to prevent multiple instances of cosmic creation.

    #region Private Fields

    private static readonly object LockObject = new();
    private static BigBang _instance;

    #endregion Private Fields

    #region Public Properties

    public static BigBang Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (LockObject)
            {
                _instance ??= new BigBang();
            }

            return _instance;
        }
    }

    public List<Planet> Planets { get; } = new();

    #endregion Public Properties
}

public enum PlanetaryData
{
    OrbitalData
}

// ==SUMMARY== Fetches orbital data from REST API and assigns it to planet objects. Each planet's
// data is fetched based on its name. Any exceptions encountered will raise the ErrorOccurred event.
// Data is transformed using methods from TransformDataFromApi.cs.