using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Nexus.ViewModels;
using Nexus.Views;
using System.Threading.Tasks;

namespace Nexus
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                   
                var splashWindow = new SplashWindow();
                var splashViewModel = new SplashWindowViewModel();

                desktop.MainWindow = splashWindow;
                splashWindow.DataContext = splashViewModel;

                try
                {
                    await Task.Delay(2000);

                    splashViewModel.StartUpMessage = "Trying to connect to the web server..";

                    await Task.Delay(1000);

                    splashViewModel.StartUpMessage = "Trying to connect a Token..";

                    await Task.Delay(1500);

                    splashViewModel.StartUpMessage = "Ready";
                }
                catch(TaskCanceledException)
                {
                    splashWindow.Close();
                    return;
                }
                
                // Open main window
                var mainWindow = new MainWindow();
                desktop.MainWindow = mainWindow;
                mainWindow.DataContext = new MainWindowViewModel();
                mainWindow.Show();
                splashWindow.Close();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}