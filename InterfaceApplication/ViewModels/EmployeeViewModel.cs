using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class EmployeeViewModel : ObservableObject
    {

        private EmployeeInteractor Employeeinteractor;
        private ApplicationDbContext dbContext;
        private Employee? NewEmployee;

        public Employee? SelectedEmployee
        {
            get { return NewEmployee; }
            set
            {
                SetProperty(ref NewEmployee, value);
            }
        }


        public EmployeeViewModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.Employeeinteractor = new EmployeeInteractor(dbContext);
            SelectedEmployee = new Employee();
        }


        [RelayCommand]
        private void AddEmployee()
        {
            if (SelectedEmployee.Login.IsNullOrEmpty() 
                || SelectedEmployee.Password.IsNullOrEmpty()
                || SelectedEmployee.NameEmployee.IsNullOrEmpty()
                || SelectedEmployee.Address.IsNullOrEmpty())
                return;

            SelectedEmployee=Employeeinteractor.CreateEmployee(SelectedEmployee);

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

        private void Autorization(Window autorWindow)
        {

                if (SelectedEmployee.Login.IsNullOrEmpty()
                    || SelectedEmployee.Password.IsNullOrEmpty())
                    return;

                SelectedEmployee = Employeeinteractor.GetAll().FirstOrDefault(b => b.Login == SelectedEmployee.Login && b.Password == SelectedEmployee.Password);

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

