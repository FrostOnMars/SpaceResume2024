using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.Models
{
    public static class Planets
    {
        public const string Mercury = "Mercury";
        public const string Venus = "Venus";
        public const string Earth = "Earth";
        public const string Mars = "Mars";
        public const string Jupiter = "Jupiter";
        public const string Saturn = "Saturn";
        public const string Uranus = "Uranus";
        public const string Neptune = "Neptune";
        public const string Pluto = "Pluto";
    }

    public class PlanetMapping     
    {
        public static string GetPlanetImageAssetPath(string planetName)
        {
            return string.IsNullOrEmpty(planetName) ? string.Empty : planetName switch
            {
                Planets.Mercury => "pack://application:,,,/SpaceResume2024;component/Resources/Images/MercuryRound.png",
                Planets.Venus => "pack://application:,,,/SpaceResume2024;component/Resources/Images/VenusRound.png",
                Planets.Earth => "pack://application:,,,/SpaceResume2024;component/Resources/Images/EarthRound.png",
                Planets.Mars => "pack://application:,,,/SpaceResume2024;component/Resources/Images/MarsRound.png",
                Planets.Jupiter => "pack://application:,,,/SpaceResume2024;component/Resources/Images/JupiterRound.png",
                Planets.Saturn => "pack://application:,,,/SpaceResume2024;component/Resources/Images/SaturnRound.png",
                Planets.Uranus => "pack://application:,,,/SpaceResume2024;component/Resources/Images/UranusRound.png",
                Planets.Neptune => "pack://application:,,,/SpaceResume2024;component/Resources/Images/NeptuneRound.png",
                Planets.Pluto => "pack://application:,,,/SpaceResume2024;component/Resources/Images/PlutoRound.png",
                _ => throw new ArgumentException("Invalid planet name"),
            };
        }
    }
}




