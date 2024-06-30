using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class BascketViewModel : ObservableObject
    {
        private readonly BascketService _bascketService;
        private readonly CommonService<ProductDto, int> _productService;

        public BascketViewModel(EmployeeDto currentEmployee)
        {
            _bascketService = new ("Bascket");
            _productService = new("Product");
            this.currentEmployee = currentEmployee;
            Load();
        }


        private List<BascketItem> items;

        public List<BascketItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private EmployeeDto? currentEmployee;
        public EmployeeDto? CurrentEmployee
        {
            get { return currentEmployee; }
            set
            {
                SetProperty(ref currentEmployee, value);
            }
        }

        private async void Load() {

            var basckets = await _bascketService.GetAllAsync();
            basckets= basckets.Where(p => p.EmployeeId == currentEmployee.Id).ToList();
            var products= await _productService.GetAllAsync();

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

        private async void  Clear()
        {
            var basckets = await _bascketService.DeleteEmployeeEntitys(currentEmployee.Id);
            Items = new();
        }

    }
}
