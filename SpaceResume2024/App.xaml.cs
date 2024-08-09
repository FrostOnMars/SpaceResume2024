using SpaceResume2024.ViewModels.NASA;
using SpaceResume2024.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace SpaceResume2024;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ServiceProvider = ConfigureServices();

        // Create the MainWindow
        var mainWindow = new MainWindow
        {
            // Set the DataContext to the MainWindowViewModel from the service provider
            DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>()
        };

        mainWindow.Show();
    }

    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Register services, view models, etc.
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<OrbitalPathControlViewModel>();
        services.AddTransient<PlanetViewModel>();
        // ... any other services or view models

        return services.BuildServiceProvider();
    }
}