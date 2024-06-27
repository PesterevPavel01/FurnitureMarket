using InterfaceApplication.ViewModels;
using Microsoft.Extensions.DependencyInjection;

using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;


namespace InterfaceApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CategoryViewModel categoryviewmodel { get; private set; }

        public MainWindow(ApplicationDbContext dbcontext)
        {   

            categoryviewmodel = App.HostContainer.Services.GetRequiredService<CategoryViewModel>();

            DataContext = categoryviewmodel;

            EmployeeInteractor Employeeinteractor = new EmployeeInteractor(dbcontext);

            var SelectedEmployee = Employeeinteractor.GetAll();

            InitializeComponent();
            
        }

       
    }
}
