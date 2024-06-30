using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class EmployeeViewModel : ObservableObject
    {
        
        private readonly CommonService<EmployeeDto, int> _employeeService;
        private EmployeeDto? NewEmployee;

        public EmployeeDto? SelectedEmployee
        {
            get { return NewEmployee; }
            set
            {
                SetProperty(ref NewEmployee, value);
            }
        }


        public EmployeeViewModel()
        {
            _employeeService = new("Employee");
            SelectedEmployee = new ();
        }


        [RelayCommand]
        private async void AddEmployee()
        {
            if (SelectedEmployee.Login.IsNullOrEmpty() 
                || SelectedEmployee.Password.IsNullOrEmpty()
                || SelectedEmployee.NameEmployee.IsNullOrEmpty()
                || SelectedEmployee.Address.IsNullOrEmpty())
                return;

            var result = await _employeeService.CreateAsync(SelectedEmployee);



            if (SelectedEmployee == null)
            {
                MessageBox.Show("пользователь не зарегистрирован");
            }
            else 
            {
                MessageBox.Show("пользователь зарегистрирован");
            }

        }

        [RelayCommand]

        private async void Autorization(Window autorWindow)
        {

                if (SelectedEmployee.Login.IsNullOrEmpty()
                    || SelectedEmployee.Password.IsNullOrEmpty())
                    return;

            var employees = await _employeeService.GetAllAsync();
            SelectedEmployee = employees.FirstOrDefault(b => b.Login == SelectedEmployee.Login && b.Password == SelectedEmployee.Password);

            if (SelectedEmployee != null)
            {
                autorWindow.Close();
            }
            else
            {
                SelectedEmployee = new();
                MessageBox.Show("Упс... что-то не так");
            }

        }
    }


}

