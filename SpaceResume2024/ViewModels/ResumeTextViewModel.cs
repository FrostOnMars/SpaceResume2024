using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models;

namespace SpaceResume2024.ViewModels;

public partial class ResumeTextViewModel : ObservableObject
{
    #region Private Fields

    [ObservableProperty] private ResumeInfo? _resumeInfo;
    [ObservableProperty] private ImageAssetPathModel? _imageAssetPathModel;
    [ObservableProperty] private string? _planetName;

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
    }

    #endregion Public Constructors
}