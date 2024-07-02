using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceResume2024.Models;

namespace SpaceResume2024.ViewModels;

public partial class ResumeTextViewModel : ObservableObject
{
    [ObservableProperty] private ResumeInfo? _resumeInfo;

    public ResumeTextViewModel()
    {
        ResumeInfo ??= new ResumeInfo();
    }

    public ResumeTextViewModel(ResumeInfo resumeInfo)
    {
        ResumeInfo = resumeInfo;
    }

}