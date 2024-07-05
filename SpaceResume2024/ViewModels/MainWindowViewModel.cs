using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResume2024.Models;

namespace SpaceResume2024.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    #region Public Properties

    //public List<ResumeTextViewModel> ResumeTextViewModels { get; } = [];
    [ObservableProperty] private ObservableCollection<ResumeTextViewModel> _resumeTextViewModels = new();
    public double ScreenHeight { get; set; }
    public double ScreenWidth { get; set; }

    #endregion Public Properties

    #region Public Constructors
    public MainWindowViewModel()
    {
        GetResumeText();
        ScreenHeight = SystemParameters.PrimaryScreenHeight;
        ScreenWidth = SystemParameters.PrimaryScreenWidth;
    }
    #endregion


    #region Public Methods

    public void GetResumeText()
    {
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
        }));
       
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
        }));

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
            }
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
            }
        });
    }

    #endregion Public Methods
}