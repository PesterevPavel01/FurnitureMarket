using InterfaceApplication.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace InterfaceApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? HostContainer { get; private set; }

        public App()
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow> ();
                services.AddSingleton<CategoryViewModel>();
            }
            );

            HostContainer = builder.Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await HostContainer!.StartAsync();

            var startUpForm = HostContainer.Services.GetRequiredService<MainWindow>();

            startUpForm.Show();

            base.OnStartup(e);
        }


    }

}
