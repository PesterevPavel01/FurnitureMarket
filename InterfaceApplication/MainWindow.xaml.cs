using CommunityToolkit.Mvvm.Input;
using ExcellReports;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using InterfaceApplication.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Windows;


namespace InterfaceApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CategoryViewModel categoryviewmodel { get; private set; }

        public MainWindow()
        {   

            categoryviewmodel = App.HostContainer.Services.GetRequiredService<CategoryViewModel>();

            DataContext = categoryviewmodel;

            InitializeComponent();
            
        }
    }
}
