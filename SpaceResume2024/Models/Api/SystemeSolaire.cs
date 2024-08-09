using SpaceResume2024.ViewModels.NASA;

namespace SpaceResume2024.Models.Api;

public class SystemeSolaire
{
    #region Public Methods

    public string AssembleUrl(PlanetaryData type)
    {
        return type switch
        {
            PlanetaryData.OrbitalData => $"{BaseUrl}{OrbitalDataUrl}",
            //PlanetaryData.PlanetDescription => $"{_baseUrl}{PlanetDescriptionUrl}",
            //PlanetaryData.PlanetCoordinates => $"{_baseUrl}{CoordinatesUrl}",
            _ => string.Empty
        };
    }

    #endregion Public Methods

    #region Private Fields

    private const string BaseUrl = "https://api.le-systeme-solaire.net/";
    private const string OrbitalDataUrl = "/rest/bodies/";

    #endregion Private Fields
}