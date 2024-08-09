using SpaceResume2024.Models.PlanetModels;

namespace SpaceResume2024.ViewModels.NASA;

public class GetOrbitalDataFromApi
{
    private readonly BigBang _instance = BigBang.Instance;
    private readonly DataSources _dataSources = new();

    public delegate void ErrorHandler(string errorMessage);
    public static event ErrorHandler? ErrorOccurred;

    #region GetPlanetDataFromRestApi() uses AssembleURL() & requests API Client
    public string? GetPlanetDataFromRestApi(string planetName)
    {
        var client = new RestClient(_dataSources.SolarSystemAPI.AssembleURL(PlanetaryData.OrbitalData));
        var request = new RestRequest($"{_dataSources.SolarSystemAPI.AssembleURL(PlanetaryData.OrbitalData)}{planetName}");

        var response = client.Execute(request);

        return response.IsSuccessful
            ? response.Content
            : string.Empty;
    }

    #endregion

    #region GetDataFromRestApi() names the planets, uses Terraform(), and deserializes Json
    private void GetDataFromRestApi()
    {
        try
        {
            var planetNames = new List<string>
            {
                "Mercury",
                "Venus",
                "Earth",
                "Mars",
                "Jupiter",
                "Saturn",
                "Uranus",
                "Neptune",
                "Pluto"
            };
            foreach (var jsonString in planetNames
                         .Select(GetPlanetDataFromRestApi)
                         .Where(jsonString => string
                             .IsNullOrEmpty(jsonString) == false))
            {
                _instance.Planets
                    .Add(Planet.Terraform(JsonConvert.DeserializeObject<OrbitalDataModel>(jsonString)));
            }
        }
        catch (Exception ex)
        {
            // Raise the event when an error occurs.
            ErrorOccurred?.Invoke(ex.Message);
        }
    }
    #endregion// GetDataFromRestApi() names the planets

    #region GetData() uses GetPlanetDataFromRestApi(), uses methods from TransformData to scale size.
    public void GetData(PlanetaryData dataType, double screenWidth, double screenHeight)
    {
        try
        {
            switch (dataType)
            {
                case PlanetaryData.OrbitalData:
                    GetDataFromRestApi();
                    TransformDataFromApi.ToUsableSizes(screenWidth, screenHeight);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke(ex.Message);
        }
    }

    #endregion
}