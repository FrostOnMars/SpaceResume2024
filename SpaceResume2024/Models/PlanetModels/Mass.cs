﻿namespace SpaceResume2024.Models.PlanetModels;

public class Mass
{
    #region Public Properties

    public double massExponent { get; set; }
    public double massValue { get; set; }

    #endregion Public Properties
}

[Serializable]
public class OrbitalDataModel
{
    #region Public Constructors

    /// <summary>
    /// This class contains properties for the orbital data of a planet divided in three sections:
    /// general, mass, and volumeExecutes the request synchronously, authenticating if needed
    /// </summary>
    public OrbitalDataModel(object aroundPlanet, string discoveryDate, string englishName, Mass mass, Vol vol)
    {
        this.aroundPlanet = aroundPlanet;
        this.discoveryDate = discoveryDate;
        this.englishName = englishName;
        this.mass = mass;
        this.vol = vol;
    }

    #endregion Public Constructors

    #region Public Properties

    public string? alternativeName { get; set; }
    public double aphelion { get; set; }
    public double argPeriapsis { get; set; }
    public object aroundPlanet { get; set; }
    public double avgTemp { get; set; }
    public double axialTilt { get; set; }
    public string? bodyType { get; set; }
    public double density { get; set; }
    public string? dimension { get; set; }
    public string? discoveredBy { get; set; }
    public string discoveryDate { get; set; }
    public double eccentricity { get; set; }
    public string englishName { get; set; }
    public double equaRadius { get; set; }
    public double escape { get; set; }
    public double flattening { get; set; }
    public double gravity { get; set; }
    public string? id { get; set; }
    public double inclination { get; set; }
    public bool isPlanet { get; set; }
    public double longAscNode { get; set; }
    public double mainAnomaly { get; set; }
    public Mass mass { get; set; }
    public double meanRadius { get; set; }
    public object? moons { get; set; }
    public string? name { get; set; }
    public double perihelion { get; set; }
    public double polarRadius { get; set; }
    public double semimajorAxis { get; set; }
    public double semiMinorAxis { get; set; }
    public double sideralOrbit { get; set; }
    public double sideralRotation { get; set; }
    public Vol vol { get; set; }

    #endregion Public Properties
}

public class Planet
{
    #region Private Constructors

    private Planet()
    {
        SimulationVelocity = 0;
    }

    #endregion Private Constructors

    #region Public Properties

    public string? Description { get; set; }
    public string? Name { get; set; }
    public OrbitalDataModel? OrbitalData { get; set; }
    public double SimulationVelocity { get; set; }

    #endregion Public Properties

    #region need to move this region to the pathing region

    public double Diameter { get; set; }
    public double Distance { get; set; }
    public double EllipseCircumference { get; set; }
    public double PlanetaryVelocity { get; set; }
    public double Scale { get; set; }
    public uint ScaleFactor { get; set; }

    #endregion need to move this region to the pathing region

    #region Public Methods

    public static Planet Terraform(string name)
    {
        return new Planet
        {
            Name = name
        };
    }

    public static Planet Terraform(OrbitalDataModel orbitalData)
    {
        return new Planet
        {
            OrbitalData = orbitalData,
            Name = orbitalData.englishName
        };
    }

    #endregion Public Methods
}

public class Vol
{
    #region Public Constructors

    /// <summary>
    /// This class contains properties for the volume of a planet.
    /// </summary>
    public Vol()
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public double volExponent { get; set; }
    public double volValue { get; set; }

    #endregion Public Properties
}

public class SqlPlanetModel
{
    #region Public Properties

    public int AutoId { get; set; }
    public string? Misc { get; set; }
    public string? PlanetDescription { get; set; }
    public string? PlanetName { get; set; }
    public string? PlanetOrder { get; set; }

    #endregion Public Properties
}