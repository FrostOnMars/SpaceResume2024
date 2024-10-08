﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResume2024.Models;
using SpaceResume2024.ViewModels.NASA;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SpaceResume2024.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    #region Public Constructors

    public MainWindowViewModel()
    {
        GetResumeText();
        ScreenHeight = SystemParameters.PrimaryScreenHeight;
        ScreenWidth = SystemParameters.PrimaryScreenWidth;
    }

    #endregion Public Constructors

    #region Public Properties

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string? _firstName = "Mikayla";

    [ObservableProperty] private string? _fullName;

    [ObservableProperty] private ObservableCollection<ImageAssetPathModel> _imageAssetPaths = [];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string? _lastName = "Martin";

    [ObservableProperty] private double _maxWidth;

    [ObservableProperty] private string? _mouseCoordinates;

    [ObservableProperty]
    private ObservableCollection<PlanetViewModel> _planetViewModels;

    //public List<ResumeTextViewModel> ResumeTextViewModels { get; } = [];
    [ObservableProperty] private ObservableCollection<ResumeTextViewModel> _resumeTextViewModels = [];

    [ObservableProperty] private double _screenHeight;
    [ObservableProperty] private double _screenWidth;

    #endregion Public Properties

    #region Public Methods

    private bool CanClick => FirstName == "Mikayla" && LastName == "Martin";

    private static void HandleOrbitalDataError(string errorMessage)
    {
        // Here, you need to make sure that you display the message box on the UI thread. If using
        // MVVM properly, you'd typically send a message to the view or use some service to show the error.
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private static double MeasureMaxBodyWidth(IEnumerable<string> body, double fontSize)
    {
        return body.Select(line => MeasureTextWidth(line, fontSize, FontWeights.Normal)).Prepend(0).Max();
    }

    private static double MeasureTextWidth(string text, double fontSize, FontWeight fontWeight)
    {
        if (string.IsNullOrEmpty(text)) return 0;

        var formattedText = new FormattedText(
            text,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, fontWeight, FontStretches.Normal),
            fontSize,
            Brushes.Black,
            VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

        return formattedText.WidthIncludingTrailingWhitespace;
    }

    private void CalculateMaxWidth()
    {
        var maxWidth = ResumeTextViewModels
            .Select(resumeTextViewModel => new
            {
                resumeTextViewModel,
                titleWidth = MeasureTextWidth(resumeTextViewModel.ResumeInfo.Title, 24, FontWeights.Bold)
            })
            .Select(t => new { t, bodyWidth = MeasureMaxBodyWidth(t.resumeTextViewModel.ResumeInfo.Body, 16) })
            .Select(t => Math.Max(t.t.titleWidth, t.bodyWidth)).Prepend(0).Max();
        MaxWidth = maxWidth;
    }

    public void GetResumeText()
    {
        ResumeTextViewModels.Clear();
        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = "Professional Goals",
                Body =
                [
                    "To develop an in-depth understanding of a variety of object-oriented computer languages.",
                    "Grow my skills as a Developer and advance in my career.",
                    "Build a solid foundation for professional development by performing well in a big business setting.",
                    "If hired, will work hard to pursue advancement and training opportunities in a professional environment.",
                    "Interested in working with a business with a clear path to success for employees who work hard and deliver results."
                ]
            },
            ImageAssetPathModel = new ImageAssetPathModel { Name = Planets.Mercury, Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Mercury) },
            PlanetName = Planets.Mercury,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Mercury)
        });

        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = "Work Experience",
                Body =
                [
                    "Software Developer, 2019 - Present",
                    "Company Name, City, State",
                    "Responsibilities:",
                    "Developed and maintained software applications for various clients.",
                    "Worked with a team of developers to meet project requirements.",
                    "Participated in code reviews and provided feedback to other developers.",
                    "Collaborated with other departments to ensure project success."
                ]
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Venus,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Venus)
            },
            PlanetName = Planets.Venus,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Venus)
        });

        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = "Education",
                Body =
                [
                    "Bachelor of Science in Computer Science, 2019",
                    "University Name, City, State",
                    "Relevant Coursework:",
                    "Data Structures and Algorithms",
                    "Object-Oriented Programming",
                    "Database Management Systems",
                    "Software Engineering"
                ]
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Earth,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Earth)
            },
            PlanetName = Planets.Earth,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Earth)
        });

        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = "Skills",
                Body =
                [
                    "Programming Languages: C#, Java, Python",
                    "Web Technologies: HTML, CSS, JavaScript",
                    "Database Management: SQL, MySQL",
                    "Version Control: Git, GitHub",
                    "Operating Systems: Windows, Linux"
                ]
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Mars,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Mars)
            },
            PlanetName = Planets.Mars,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Mars)
        });

        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = string.Empty,
                Body = []
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Jupiter,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Jupiter)
            },
            PlanetName = Planets.Jupiter,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Jupiter)
        });
        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = string.Empty,
                Body = []
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Saturn,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Saturn)
            },
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Saturn),
            PlanetName = Planets.Saturn,
        }); ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = string.Empty,
                Body = []
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Uranus,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Uranus)
            },
            PlanetName = Planets.Uranus,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Uranus)
        });
        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = string.Empty,
                Body = []
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Neptune,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Neptune)
            },
            PlanetName = Planets.Neptune,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Neptune)
        }); ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            ResumeInfo = new ResumeInfo
            {
                Title = string.Empty,
                Body = []
            },
            ImageAssetPathModel = new ImageAssetPathModel
            {
                Name = Planets.Pluto,
                Path = PlanetMapping.GetPlanetImageAssetPath(Planets.Pluto)
            },
            PlanetName = Planets.Pluto,
            PlanetImage = PlanetMapping.GetPlanetImageAssetPath(Planets.Pluto)
        });

        //foreach (var vm in ResumeTextViewModels)
        //{
        //    vm.SetPlanetImage();
        //}
    }

    public void UpdateCoordinates(Point point)
    {
        var screenWidth = SystemParameters.PrimaryScreenWidth;
        var screenHeight = SystemParameters.PrimaryScreenHeight;

        point.X -= (screenWidth / 2);
        point.Y = (screenHeight / 2) - point.Y;

        MouseCoordinates = $"X: {point.X:N0}, Y: {point.Y:N0}";
    }

    //everything below is in the wrong place and will be moved later

    #region GeneratePlanetPaths() and LogScale() to be moved later

    public void GeneratePlanetPaths()
    {
    }

    public double LogScale(double distanceKm, double minDistanceKm, double maxDistanceKm, double minScale, double maxScale)
    {
        // Ensure the distance is clamped between min and max
        distanceKm = Math.Max(minDistanceKm, Math.Min(maxDistanceKm, distanceKm));

        // Calculate the logarithmic scales for min, max and current distance
        double logMin = Math.Log(minDistanceKm);
        double logMax = Math.Log(maxDistanceKm);
        double logValue = Math.Log(distanceKm);

        // Map the log scales to window units
        double scale = minScale + (maxScale - minScale) * ((logValue - logMin) / (logMax - logMin));

        return scale;
    }

    #endregion GeneratePlanetPaths() and LogScale() to be moved later

    #endregion Public Methods
}