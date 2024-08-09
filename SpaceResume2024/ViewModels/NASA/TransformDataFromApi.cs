﻿using Newtonsoft.Json.Linq;
using SpaceResume2024.Models.PlanetModels;
using System.Net.Http;

namespace SpaceResume2024.ViewModels.NASA;

public class TransformDataFromApi : GetOrbitalDataFromApi
{
    #region Public Delegates

    public delegate void ErrorHandler(string errorMessage);

    #endregion Public Delegates

    // ==SUMMARY== Data from the API have sizes too large to be displayed on a screen. This class
    // scales the data to fit the screen. This data will be used for ellipse and animation logic.

    #region Public Events

    public static event ErrorHandler? ErrorOccurred;

    #endregion Public Events

    #region ToUsableSizes() scales the ellipse size to fit the screen

    public static void ToUsableSizes(double screenWidth, double screenHeight)
    {
        try
        {
            foreach (var planet in BigBang.Instance.Planets.OrderByDescending(p => p.OrbitalData.semimajorAxis))
            {
                // This is the time scale factor
                planet.ScaleFactor = 40000;
                if (planet.OrbitalData == null) continue;

                // Modify the semi major and semi minor axes of the ellipse
                planet.OrbitalData.semimajorAxis = planet.OrbitalData.semimajorAxis;
                planet.OrbitalData.semiMinorAxis = CalculateSemiMinorAxis(planet.OrbitalData.semimajorAxis,
                    planet.OrbitalData.eccentricity);
            }

            ScaleOrbitsWithScreenDimensions(BigBang.Instance.Planets, screenWidth, screenHeight);
            ScalePlanetDiameters(BigBang.Instance.Planets);
        }
        catch (Exception ex)
        {
            // Raise the event when an error occurs.
            ErrorOccurred?.Invoke(ex.Message);
        }
    }

    #endregion ToUsableSizes() scales the ellipse size to fit the screen

    #region ScaleOrbitsWithMinMax() scales the ellipse orbits to constants

    public static void ScaleOrbitsWithMinMax(List<Planet> planets)
    {
        const double minScreenOrbitSize = 100;
        const double maxScreenOrbitSize = 1700;

        var minOrbit = planets.Min(p => p.OrbitalData!.semimajorAxis);
        var maxOrbit = planets.Max(p => p.OrbitalData!.semimajorAxis);

        foreach (var planet in planets)
        {
            var originalSize = planet.OrbitalData!.semimajorAxis;

            // Determine what percentage the original size is of the total range
            var percentOfOriginalRange = (originalSize - minOrbit) / (maxOrbit - minOrbit);

            // Apply this percentage to the screen size range
            var screenSize = minScreenOrbitSize + percentOfOriginalRange * (maxScreenOrbitSize - minScreenOrbitSize);

            // Calculate the scaling factor for the semimajorAxis
            var scalingFactor = screenSize / originalSize;

            planet.OrbitalData.semimajorAxis = screenSize;

            // Apply the same scaling factor to the semiMinorAxis
            planet.OrbitalData.semiMinorAxis *= scalingFactor;
        }
    }

    #endregion ScaleOrbitsWithMinMax() scales the ellipse orbits to constants

    #region ScaleOrbitsWithScreenDimensions() scales the ellipse orbits according to variable screen.

    public static void ScaleOrbitsWithScreenDimensions(List<Planet> planets, double screenWidth, double screenHeight)
    {
        const double minScreenOrbitSize = 100;

        var minOrbit = planets.Min(p => p.OrbitalData!.semimajorAxis);
        var maxOrbit = planets.Max(p => p.OrbitalData!.semimajorAxis);

        foreach (var planet in planets)
        {
            var originalSize = planet.OrbitalData!.semimajorAxis;

            // Determine what percentage the original size is of the total range
            var percentOfOriginalRange = (originalSize - minOrbit) / (maxOrbit - minOrbit);

            // Apply this percentage to the screen size range
            var screenSize = minScreenOrbitSize + percentOfOriginalRange * (screenWidth - minScreenOrbitSize);

            // Calculate the scaling factor for the semimajorAxis
            var scalingFactor = screenSize / originalSize;

            planet.OrbitalData.semimajorAxis = screenSize;

            // Apply the same scaling factor to the semiMinorAxis
            planet.OrbitalData.semiMinorAxis *= scalingFactor;
        }
    }

    #endregion ScaleOrbitsWithScreenDimensions() scales the ellipse orbits according to variable screen.

    #region CalculateSemiMinorAxis() calculates the semi-minor axis of an ellipse

    /// <summary>
    /// Calculates the semi-minor axis of an ellipse given its semi-major axis and eccentricity.
    /// </summary>
    /// <param name="semiMajorAxis"> The semi-major axis of the ellipse. </param>
    /// <param name="eccentricity">  The eccentricity of the ellipse. </param>
    /// <returns> The calculated semi-minor axis value. </returns>
    public static double CalculateSemiMinorAxis(double semiMajorAxis, double eccentricity)
    {
        return semiMajorAxis * Math.Sqrt(1 - eccentricity * eccentricity);
    }

    #endregion CalculateSemiMinorAxis() calculates the semi-minor axis of an ellipse

    #region ScalePlanetDiameters() scales the planet diameters to constants

    /// <summary>
    /// Scales the diameters of planets for visualization purposes.
    /// </summary>
    /// <param name="planets"> List of planet objects whose diameters are to be scaled. </param>
    /// <remarks> This method adjusts the diameters of planets based on their equatorial radii. </remarks>
    public static void ScalePlanetDiameters(List<Planet> planets)
    {
        if (planets.Any(p => p.OrbitalData == null)) return;
        // Define the minimum and maximum diameters for the display.
        const double minDiameter = 20;
        const double maxDiameter = 150;

        // 1. Find the minimum and maximum equatorial radius.
        var minRadius = planets.Min(p => p.OrbitalData!.equaRadius);
        var maxRadius = planets.Max(p => p.OrbitalData!.equaRadius);

        // 2. Determine the scaling factor based on both minimum and maximum planet sizes.
        foreach (var planet in planets)
        {
            var originalDiameter = 2 * planet.OrbitalData!.equaRadius;

            // Determine what percentage the original diameter is of the total range.
            var percentOfOriginalRange = (originalDiameter - 2 * minRadius) / (2 * (maxRadius - minRadius));

            // Apply this percentage to the screen size range.
            var scaledDiameter = minDiameter + percentOfOriginalRange * (maxDiameter - minDiameter);

            planet.Diameter = scaledDiameter;
        }
    }

    #endregion ScalePlanetDiameters() scales the planet diameters to constants

    #region Obsolete Methods

    public static double SigmoidScale(double value, double maxValue, double minValue)
    {
        var range = maxValue - minValue;
        var mid = (maxValue + minValue) / 2;

        var k = 50.0 / range; // This controls the 'steepness' of the curve. You can adjust as required.
        var xShifted = (value - mid) * k;

        return 1.0 / (1.0 + Math.Exp(-xShifted));
    }

    /// <summary>
    /// Calculates the average orbital velocity of a planet with an elliptical orbit.
    /// </summary>
    /// <param name="semiMajorAxisKm">   Semi-major axis of the planet's orbit in kilometers. </param>
    /// <param name="semiMinorAxisKm">   Semi-minor axis of the planet's orbit in kilometers. </param>
    /// <param name="siderealOrbitDays"> Sidereal orbital period of the planet in days. </param>
    /// <returns> The average orbital velocity in km/h. </returns>
    public double CalculateRealOrbitalVelocity(double semiMajorAxisKm, double semiMinorAxisKm, double siderealOrbitDays)
    {
        // Convert sidereal orbit from days to seconds
        var siderealOrbitSeconds = siderealOrbitDays * 24 * 60 * 60;

        // Calculate the approximate circumference of the real elliptical orbit using Ramanujan's formula
        var orbitCircumferenceKm = Math.PI * (3 * (semiMajorAxisKm + semiMinorAxisKm) -
                                              Math.Sqrt((3 * semiMajorAxisKm + semiMinorAxisKm) *
                                                        (semiMajorAxisKm + 3 * semiMinorAxisKm)));

        // Calculate and return the real average orbital velocity
        return orbitCircumferenceKm / siderealOrbitSeconds * 3600; // Multiply by 3600 to convert km/s to km/h
    }

    public double ComputeSimulationVelocity(double realVelocityKmH, double scalingFactor)
    {
        return realVelocityKmH * scalingFactor;
    }

    public double FindScaleFactorAndResize(ref double semiMajorAxis, ref double semiMinorAxis,
        ref double existingScaleFactor)
    {
        double maxScreenHeight = 750;
        double maxScreenWidth = 750;

        // If we have an existing scale factor, apply it and return
        if (existingScaleFactor != 0)
        {
            semiMajorAxis *= existingScaleFactor;
            semiMinorAxis *= existingScaleFactor;
            return existingScaleFactor;
        }

        var originalSemiMajor = semiMajorAxis;
        var originalSemiMinor = semiMinorAxis;

        // Define a reasonable threshold; this will prevent us from scaling down too much
        var threshold = 0.95; // 95%

        // Start the scale factor at 1 and decrease it iteratively
        var scaleFactor = 1.0;

        while (semiMajorAxis > maxScreenWidth || semiMinorAxis > maxScreenHeight)
        {
            scaleFactor *= threshold; // Decrease the scale factor
            semiMajorAxis = originalSemiMajor * scaleFactor;
            semiMinorAxis = originalSemiMinor * scaleFactor;
        }

        return scaleFactor;
    }

    public async Task<JObject> GetPlanetDataAsync(string planetName)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync($"https://api.le-systeme-solaire.net/rest/bodies/{planetName}");
            return JObject.Parse(response);
        }
    }

    public double ResizeEllipseToFitScreen(ref double semiMajorAxis, ref double semiMinorAxis)
    {
        double maxScreenHeight = 750;
        double maxScreenWidth = 750;

        // Calculate the logarithmic scales for the semi-major and semi-minor axes
        var logSemiMajorAxis = Math.Log(semiMajorAxis);
        var logSemiMinorAxis = Math.Log(semiMinorAxis);

        // Map the logarithmic scales to fit within the screen dimensions logarithmically
        var logMaxScreenWidth = Math.Log(maxScreenWidth);
        var logMaxScreenHeight = Math.Log(maxScreenHeight);

        var scaledLogSemiMajorAxis = logSemiMajorAxis - logMaxScreenWidth;
        var scaledLogSemiMinorAxis = logSemiMinorAxis - logMaxScreenHeight;

        // Apply the exponential function to revert the logarithmic scaling
        semiMajorAxis = Math.Exp(scaledLogSemiMajorAxis);
        semiMinorAxis = Math.Exp(scaledLogSemiMinorAxis);

        // Calculate the scaled circumference using Ramanujan's formula
        var scaledCircumference = Math.PI * (3 * (semiMajorAxis + semiMinorAxis) -
                                             Math.Sqrt((3 * semiMajorAxis + semiMinorAxis) *
                                                       (semiMajorAxis + 3 * semiMinorAxis)));

        return scaledCircumference;
    }

    public void ScalePlanetsToFitScreen(List<Planet> planets)
    {
        double maxScreenDimension = 750; // Adjust this as per your requirements.
        double minScreenDimension = 10; // Adjust this as per your requirements.

        // 1. Determine the Range
        var maxSemiMajor = planets.Max(p => p.OrbitalData.semimajorAxis);
        var minSemiMajor = planets.Min(p => p.OrbitalData.semimajorAxis);

        foreach (var planet in planets)
        {
            // 2. Scale the Values with Sigmoid
            var scaledSemiMajor = SigmoidScale(planet.OrbitalData.semimajorAxis, maxSemiMajor, minSemiMajor);

            // 3. Linearly Scale the Sigmoid Value to Screen Dimensions
            planet.OrbitalData.semimajorAxis =
                minScreenDimension + scaledSemiMajor * (maxScreenDimension - minScreenDimension);

            // Ensure semi-minor axis is scaled accordingly to maintain the ellipse's proportions
            var aspectRatio = planet.OrbitalData.semiMinorAxis / planet.OrbitalData.semimajorAxis;
            planet.OrbitalData.semiMinorAxis = planet.OrbitalData.semimajorAxis * aspectRatio;
        }
    }

    #endregion Obsolete Methods
}