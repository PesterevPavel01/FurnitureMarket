using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class BascketViewModel : ObservableObject
    {
        private ApplicationDbContext dbContext;
        private EmployeeInteractor employeeInterator;
        private BascketInteractor bascketInterator;
        private ProductIteractors productInterator;

        public BascketViewModel(ApplicationDbContext dbContext,Employee currentEmployee)
        {
            this.dbContext = dbContext;
            bascketInterator = new(dbContext);
            productInterator = new(dbContext);
            employeeInterator= new(dbContext);
            this.currentEmployee = currentEmployee;
            Load();
        }


        private List<BascketItem> items;

        public List<BascketItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private Employee? currentEmployee;
        public Employee? CurrentEmployee
        {
            get { return currentEmployee; }
            set
            {
                SetProperty(ref currentEmployee, value);
            }
        }

        private void Load() {

            var basckets=bascketInterator.GetAll().Where(p => p.EmployeeId == currentEmployee.Id).ToList();
            var products=productInterator.GetAll().ToList();

            try
            {
                Items = (from p in products
                              join b in basckets
                              on p.Id equals b.ProductId
                              select new BascketItem { Id = b.Id, Name= currentEmployee.NameEmployee,
                                  NameProduct = p.Name, Number = b.Number,
                                  Sum = b.Number * Convert.ToDouble(p.Price), 
                                  Date = DateTime.Now}).ToList();
            }
            catch {
                MessageBox.Show("Не удалось загрузить отчет","Ошибка");
                return;
            }
        }
    

        [RelayCommand]

        private void Clear()
        {
            var basckets = bascketInterator.GetAll().Where(p => p.EmployeeId == currentEmployee.Id).ExecuteDeleteAsync();
            Items = new();
        }

    }
}
