namespace SpaceResume2024.Models;

public static class Planets
{
    public const string Mercury = "Mercury";
    public const string Venus = "Venus";
    public const string Earth = "Earth";
    public const string Mars = "Mars";
    public const string Jupiter = "Jupiter";
    public const string Saturn = "Saturn";
    public const string Uranus = "Uranus";
    public const string Neptune = "Neptune";
    public const string Pluto = "Pluto";
}

public class PlanetMapping     
{
    public static string GetPlanetImageAssetPath(string planetName)
    {
        return string.IsNullOrEmpty(planetName) ? string.Empty : planetName switch
        {
            Planets.Mercury => "/Resources/Images/MercuryRound.png",
            Planets.Venus => "/Resources/Images/VenusRound.png",
            Planets.Earth => "/Resources/Images/EarthRound.png",
            Planets.Mars => "/Resources/Images/MarsRound.png",
            Planets.Jupiter => "/Resources/Images/JupiterRound.png",
            Planets.Saturn => "/Resources/Images/SaturnRound.png",
            Planets.Uranus => "/Resources/Images/UranusRound.png",
            Planets.Neptune => "/Resources/Images/NeptuneRound.png",
            Planets.Pluto => "/Resources/Images/PlutoRound.png",
            _ => throw new ArgumentException("Invalid planet name"),
        };
    }
}