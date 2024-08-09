using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceResume2024.Views;

/// <summary>
/// Interaction logic for PlanetControl.xaml
/// </summary>
[ObservableObject]
public partial class PlanetControl : UserControl
{
    [ObservableProperty]
    private double _diameter;
    public PlanetControl()
    {
        InitializeComponent();
        //Diameter = Ellipse.Height;
    }
}