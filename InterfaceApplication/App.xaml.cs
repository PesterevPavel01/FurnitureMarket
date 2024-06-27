using System.Configuration;
using System.Windows;
using InterfaceApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.DependencyInjection;

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
            string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            builder.ConfigureServices((context, services) =>
            {
                services.AddDataAccessLayer(ConnectionString);
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
