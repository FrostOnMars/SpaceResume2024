using SpaceResume2024.ViewModels.NASA;

namespace SpaceResume2024.Models.Api;

public class SystemeSolaire
{
    private const string BaseUrl = "https://api.le-systeme-solaire.net/";
    private const string OrbitalDataUrl = "/rest/bodies/";

    public string AssembleUrl(PlanetaryData type)
    {
        return type switch
        {
            PlanetaryData.OrbitalData => $"{BaseUrl}{OrbitalDataUrl}",
            //PlanetaryData.PlanetDescription => $"{_baseUrl}{PlanetDescriptionUrl}",
            //PlanetaryData.PlanetCoordinates => $"{_baseUrl}{CoordinatesUrl}",
            _ => string.Empty,
        };
    }
}