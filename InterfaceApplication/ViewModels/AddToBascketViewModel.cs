using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using System.Windows;
using System.Windows.Controls;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class AddToBascketViewModel : ObservableObject
    {
        private readonly CommonService<BascketDto, int> _bascketService;

        public AddToBascketViewModel()
        {
            _bascketService = new("Bascket");
        }

        private string number;
        private double sum;

        public double Sum
        {
            get { return sum; }
            set { SetProperty(ref sum, value); }
        }

        public string Number
        {
            get { return number; }
            set { SetProperty(ref number, value); }
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

        private ProductDto? selectedProduct;
        public ProductDto? SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                SetProperty(ref selectedProduct, value);
            }
        }

        [RelayCommand]
        private void AddToBascket()
        { 
            double value;
            if (SelectedProduct == null || currentEmployee == null)
                return; 
            if (number.Trim() == "") 
                return;
            if (number.Trim().Length == 0) 
                return;

            try {
                value = Convert.ToDouble(number);
            } catch {
                return;
            }

            var result= _bascketService.CreateAsync(
                new BascketDto {
                    EmployeeId=currentEmployee.Id,
                    Number= value,
                    ProductId=SelectedProduct.Id,
                });

            if (result != null)
            {
                MessageBox.Show("Товар добавлен в корзину", "Уведомление");
            }
            else {
                MessageBox.Show("Не удалось добавить товар", "Предупреждение");
            }

        }

        [RelayCommand]

        private void NumberTextChanged(object? textBox) {

            if (SelectedProduct == null) return;

            var numberTextBox= textBox as TextBox;
            String numberText= numberTextBox.Text;

            if (numberText.Trim()=="") return;
            if (numberText.Trim().Length == 0) return;

            try { Sum = Convert.ToDouble(numberText.Replace(".",",")) * Convert.ToDouble(SelectedProduct.Price.Replace(".", ",")); }
            catch { MessageBox.Show("Проверьте числовые значения","Предупреждение"); };

        }

    }
}
