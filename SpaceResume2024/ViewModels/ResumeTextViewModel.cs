using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models;

namespace SpaceResume2024.ViewModels;

public partial class ResumeTextViewModel : ObservableObject
{
    #region Private Fields

    [ObservableProperty] private ResumeInfo? _resumeInfo;
    [ObservableProperty] private ImageAssetPathModel? _imageAssetPathModel;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(PlanetImage))] private string _planetName;
    private string _planetImage;
    public string PlanetImage
    {
        get => string.IsNullOrEmpty(_planetImage) ? string.Empty : _planetImage;
        set
        {
            if (value == _planetImage) return;
            _planetImage = value;
            OnPropertyChanged();
        }
    }

    #endregion Private Fields

    #region Public Constructors

    public ResumeTextViewModel()
    {
        ResumeInfo ??= new ResumeInfo();
    }

    #endregion Public Constructors

    public void SetPlanetImage()
    {
        PlanetImage = PlanetMapping.GetPlanetImageAssetPath(PlanetName);
    }
}