using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;

namespace SpaceResume2024.Views;

/// <summary>
/// Interaction logic for PlanetControl.xaml
/// </summary>
[ObservableObject]
public partial class PlanetControl : UserControl
{
    #region Private Fields

    [ObservableProperty] private double _diameter;

    #endregion Private Fields

    #region Public Constructors

    public PlanetControl()
    {
        InitializeComponent();
        //Diameter = Ellipse.Height;
    }

    #endregion Public Constructors
}