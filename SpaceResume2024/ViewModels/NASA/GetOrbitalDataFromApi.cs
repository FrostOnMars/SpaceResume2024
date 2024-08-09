using Newtonsoft.Json;
using RestSharp;
using SpaceResume2024.Models.Api;
using SpaceResume2024.Models.PlanetModels;

namespace SpaceResume2024.ViewModels.NASA;

public class GetOrbitalDataFromApi
{
    #region Public Delegates

    public delegate void ErrorHandler(string errorMessage);

    #endregion Public Delegates

    #region Public Events

    public static event ErrorHandler? ErrorOccurred;

    #endregion Public Events

    #region GetPlanetDataFromRestApi() uses AssembleUrl() & requests API Client

    public string? GetPlanetDataFromRestApi(string planetName)
    {
        var client = new RestClient(_dataSources.SolarSystemAPI.AssembleUrl(PlanetaryData.OrbitalData));
        var request =
            new RestRequest($"{_dataSources.SolarSystemAPI.AssembleUrl(PlanetaryData.OrbitalData)}{planetName}");

        var response = client.Execute(request);

        return response.IsSuccessful
            ? response.Content
            : string.Empty;
    }

    #endregion GetPlanetDataFromRestApi() uses AssembleUrl() & requests API Client

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
                _instance.Planets
                    .Add(Planet.Terraform(JsonConvert.DeserializeObject<OrbitalDataModel>(jsonString)));
        }
        catch (Exception ex)
        {
            // Raise the event when an error occurs.
            ErrorOccurred?.Invoke(ex.Message);
        }
    }

    #endregion GetDataFromRestApi() names the planets, uses Terraform(), and deserializes Json

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

    #endregion GetData() uses GetPlanetDataFromRestApi(), uses methods from TransformData to scale size.

    #region Private Fields

    private readonly DataSources _dataSources = new();
    private readonly BigBang _instance = BigBang.Instance;

    #endregion Private Fields
}