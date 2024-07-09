using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models;

namespace SpaceResume2024.ViewModels;

public partial class ResumeTextViewModel : ObservableObject
{
    #region Private Fields

    [ObservableProperty] private ResumeInfo? _resumeInfo;
    [ObservableProperty] private ImageAssetPathModel? _imageAssetPathModel;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(PlanetImage))] private string _planetName;
    //public string PlanetImage => PlanetMapping.GetPlanetImageAssetPath(_planetName);
    [ObservableProperty] private string _planetImage;
    //public string PlanetImage
    //{
    //    get => _planetImage;
    //    set => SetProperty(ref _planetImage, value);
    //}

    
    #endregion Private Fields

    #region Public Constructors

    public ResumeTextViewModel()
    {
        ResumeInfo ??= new ResumeInfo();
    }

    public ResumeTextViewModel(ResumeInfo resumeInfo, string? planetName)
    {
        ResumeInfo = resumeInfo;
        PlanetName = planetName;
        PlanetImage = PlanetMapping.GetPlanetImageAssetPath(planetName);
    }

    #endregion Public Constructors

    public void SetPlanetImage()
    {
        PlanetImage = PlanetMapping.GetPlanetImageAssetPath(PlanetName);
    }
}