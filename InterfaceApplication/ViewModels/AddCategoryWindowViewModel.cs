using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class AddCategoryViewModel : ObservableObject
    {
        //private CategoryInteractor CInteractor;
        //private ApplicationDbContext dbContext;
        private readonly CommonService<CategoryDto, int> _categoryService = new("Category");

        public Category? newCategory;
        public Category SelectedCategory
        {
            get { return newCategory; } 
            set
            {
                SetProperty(ref newCategory, value);
            }
        }

        public AddCategoryViewModel()
        {
            //this.CInteractor = new CategoryInteractor(dbContext);
            //this.dbContext = dbContext;
            SelectedCategory = new ();
        }

     
        [RelayCommand]
        public void AddCategory(Window addCategoryWindow)
        {
            if (SelectedCategory.NameCategory.IsNullOrEmpty()
                || SelectedCategory.Description.IsNullOrEmpty()
                || SelectedCategory.ExtraCharge.IsNullOrEmpty())
                return;

            //SelectedCategory = CInteractor.CreateCategory(SelectedCategory); //было

            var result = _categoryService.CreateAsync(new(SelectedCategory)); //стало
            

            if (result != null)
            {
                addCategoryWindow.Close();
            }
            else {
                MessageBox.Show("Категория не была добавлена", "Предупреждение");
            }

        }
    }
}
