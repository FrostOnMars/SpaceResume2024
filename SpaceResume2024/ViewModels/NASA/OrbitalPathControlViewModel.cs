using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace SpaceResume2024.ViewModels.NASA;

public partial class OrbitalPathControlViewModel : ObservableObject
{
    #region Public Properties

    public PathGeometry EllipsePath
    {
        get
        {
            var semiMinor = _planetViewModel?.Planet.OrbitalData?.semiMinorAxis ?? throw new NullReferenceException();
            var semiMajor = _planetViewModel?.Planet.OrbitalData?.semimajorAxis ?? throw new NullReferenceException();

            var geometry = new PathGeometry();
            var figure = new PathFigure
            {
                StartPoint = new Point(semiMajor / 2, semiMinor / 2), // Starting at the top of the ellipse
                IsClosed = true
            };
            var segment = new ArcSegment
            {
                Point = new Point(semiMajor / 2, semiMinor / 2), // Ending at the bottom of the ellipse
                Size = new Size(semiMajor / 2, semiMinor / 2),
                IsLargeArc = true,
                SweepDirection = SweepDirection.Clockwise
            };
            figure.Segments.Add(segment);
            geometry.Figures.Add(figure);
            return geometry;
        }
    }

    #endregion Public Properties

    #region Private Fields

    [ObservableProperty] private PlanetViewModel _planetViewModel;
    [ObservableProperty] private double _semiMajorAxis;
    [ObservableProperty] private double _semiMinorAxis;
    [ObservableProperty] private double _x;
    [ObservableProperty] private double _y;

    #endregion Private Fields

    #region Public Constructors

    public OrbitalPathControlViewModel(PlanetViewModel planetViewModel)
    {
        _planetViewModel = planetViewModel;
        X = planetViewModel.X;
        Y = planetViewModel.Y;
        _semiMajorAxis = planetViewModel.SemiMajorAxis;
        _semiMinorAxis = planetViewModel.SemiMinorAxis;
    }

    public OrbitalPathControlViewModel()
    {
        _planetViewModel = new PlanetViewModel
        {
            X = 50,
            Y = 50,
            SemiMajorAxis = 200,
            SemiMinorAxis = 150
        };
        X = 50;
        Y = 50;
        _semiMajorAxis = _planetViewModel.SemiMajorAxis;
        _semiMinorAxis = _planetViewModel.SemiMinorAxis;
    }

    #endregion Public Constructors
}