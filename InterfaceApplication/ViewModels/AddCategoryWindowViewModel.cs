using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using Microsoft.IdentityModel.Tokens;
using System.Windows;

namespace InterfaceApplication.ViewModels
{
    public partial class AddCategoryViewModel : ObservableObject
    {
        private readonly CommonService<CategoryDto, int> _categoryService = new("Category");

        public CategoryDto? newCategory;
        public CategoryDto SelectedCategory
        {
            get { return newCategory; } 
            set
            {
                SetProperty(ref newCategory, value);
            }
        }

        public AddCategoryViewModel()
        {
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

            var result = _categoryService.CreateAsync(SelectedCategory); //стало
            

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
