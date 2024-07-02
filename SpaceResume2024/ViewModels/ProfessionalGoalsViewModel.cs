using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceResume2024.Models;

namespace SpaceResume2024.ViewModels;

public partial class ProfessionalGoalsViewModel : ObservableObject
{
    [ObservableProperty] private ResumeInfo? _resumeInfo;

    public ProfessionalGoalsViewModel()
    {
        GetResumeInfo();
        ResumeInfo ??= new ResumeInfo();
    }

    public void GetResumeInfo()
    {
        ResumeInfo = new ResumeInfo
        {
            Title = "Professional Goals",
            Skills =
            [
                "To develop an in-depth understanding of a variety of object-oriented computer languages.",
                "Grow my skills as a Developer and advance in my career.",
                "Build a solid foundation for professional development by performing well in a big business setting.",
                "If hired, will work hard to pursue advancement and training opportunities in a professional environment.",
                "Interested in working with a business with a clear path to success for employees who work hard and deliver results."
            ]

        };
    }
}