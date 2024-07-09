﻿using System.Collections.ObjectModel;

namespace SpaceResume2024.Models;

public class ImageAssetPathModel 
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}

public class ImageAssetPathModels : ObservableCollection<ImageAssetPathModel>
{
    public ImageAssetPathModels()
    {
        Add(new ImageAssetPathModel { Name = "Mercury", Path = "Resources/Images/MercuryRound.png" });
        Add(new ImageAssetPathModel { Name = "Venus", Path = "Resources/Images/VenusRound.png" });
        Add(new ImageAssetPathModel { Name = "Earth", Path = "Resources/Images/EarthRound.png" });
        Add(new ImageAssetPathModel { Name = "Mars", Path = "Resources/Images/MercuryRound.png" });
        Add(new ImageAssetPathModel { Name = "Jupiter", Path = "Resources/Images/MercuryRound.png" });
        Add(new ImageAssetPathModel { Name = "Saturn", Path = "Resources/Images/MercuryRound.png" });
        Add(new ImageAssetPathModel { Name = "Uranus", Path = "Resources/Images/MercuryRound.png" });
        Add(new ImageAssetPathModel { Name = "Neptune", Path = "Resources/Images/MercuryRound.png" });
        Add(new ImageAssetPathModel { Name = "Pluto", Path = "Resources/Images/MercuryRound.png" });
    }
    //C:\Code\SpaceResume2024\SpaceResume2024\Resources\Images\JupiterRound.png
}