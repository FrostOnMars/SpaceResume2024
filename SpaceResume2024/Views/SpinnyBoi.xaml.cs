using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpaceResume2024.Views;

/// <summary>
/// Interaction logic for SpinnyBoi.xaml
/// </summary>
public class SpinnyBoi : UserControl
{
    #region Public Constructors

    public SpinnyBoi()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Fields

    public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register(
        nameof(BackgroundBrush),
        typeof(Brush), typeof(SpinnyBoi), new PropertyMetadata(Brushes.White));

    public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(nameof(Duration),
        typeof(Duration), typeof(SpinnyBoi), new PropertyMetadata(default(Duration)));

    public static readonly DependencyProperty SpinnerBrushProperty = DependencyProperty.Register(nameof(SpinnerBrush),
        typeof(Brush), typeof(SpinnyBoi), new PropertyMetadata(Brushes.DodgerBlue));

    #endregion Public Fields

    #region Public Properties

    public Brush BackgroundBrush
    {
        get => (Brush)GetValue(BackgroundBrushProperty);
        set => SetValue(BackgroundBrushProperty, value);
    }

    public Duration Duration
    {
        get => (Duration)GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public Brush SpinnerBrush
    {
        get => (Brush)GetValue(SpinnerBrushProperty);
        set => SetValue(SpinnerBrushProperty, value);
    }

    #endregion Public Properties

    //FFD9DADE
}