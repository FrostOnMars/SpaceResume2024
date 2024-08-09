using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models.PlanetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.ViewModels.NASA;

public sealed class BigBang : ObservableObject
{
    //This class initializes the "Big Bang" and all the planets in it.
    //It is a singleton to prevent multiple instances of cosmic creation.

    private static readonly object LockObject = new();
    private static BigBang _instance = null;

    public List<Planet> Planets { get; } = new();

    private BigBang() { }

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

}
public enum PlanetaryData
{
    OrbitalData
}

// ==SUMMARY==
// Fetches orbital data from REST API and assigns it to planet objects.
// Each planet's data is fetched based on its name. 
// Any exceptions encountered will raise the ErrorOccurred event.
// Data is transformed using methods from TransformDataFromApi.cs.