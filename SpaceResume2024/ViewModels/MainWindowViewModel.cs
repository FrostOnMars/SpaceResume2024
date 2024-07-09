using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models;
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

    [ObservableProperty] private ObservableCollection<ImageAssetPathModel> _imageAssetPaths = [];

    [ObservableProperty] private double _maxWidth;

    //public List<ResumeTextViewModel> ResumeTextViewModels { get; } = [];
    [ObservableProperty] private ObservableCollection<ResumeTextViewModel> _resumeTextViewModels = [];

    public double ScreenHeight { get; set; }
    public double ScreenWidth { get; set; }

    #endregion Public Properties

    #region Public Methods

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

    public void GetImageAssets()
    {
        var test = new ImageAssetPathModels();

        foreach (var viewModel in ResumeTextViewModels)
        {
            //viewModel.ImageAssetPathModel = 

        }
    }

    public void GetResumeText()
    {
        //TODO: make method to get image assets
        //ImageAssetPathModel = GetImageAssets();
        //Match ViewModel to image assets by the title text
        //ResumeTextViewModels.Add(/* imageAssetPath*/)

        ResumeTextViewModels.Add(new ResumeTextViewModel(new ResumeInfo
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
        }, Planets.Mercury));

        ResumeTextViewModels.Add(new ResumeTextViewModel(new ResumeInfo
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
        }, Planets.Venus));

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
            PlanetName = Planets.Earth
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
            PlanetName = Planets.Mars
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
            PlanetName = Planets.Mars
        });
        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            PlanetName = Planets.Jupiter,
        });
        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            PlanetName = Planets.Saturn,
        }); ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            PlanetName = Planets.Uranus,
        });
        ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            PlanetName = Planets.Neptune,
        }); ResumeTextViewModels.Add(new ResumeTextViewModel
        {
            PlanetName = Planets.Pluto,
        });

        //CalculateMaxWidth();
    }

    #endregion Public Methods
}