using SpaceResume2024.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceResume2024;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _viewModel = new();

    public MainWindow()
    {

        InitializeComponent();
        DataContext = _viewModel;

        //ProfessionalGoalsTitle.Text = _viewModel.ResumeInfo.Title;
        //ProfessionalGoalsBody.Text = string.Join("\n", _viewModel.ResumeInfo.Body);



    }

}