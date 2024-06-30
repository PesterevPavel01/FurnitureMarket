using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using Microsoft.IdentityModel.Tokens;
using System.Windows;

namespace InterfaceApplication.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {

        #region Category

        public CategoryDto? selectedCategory;
        public CategoryDto? SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                SetProperty(ref selectedCategory, value);
            }
        }

        private List<CategoryDto> categories;
        public List<CategoryDto> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        #endregion

        private readonly CommonService<ProductDto, int> _productService= new("Product");

        public CategoryDto currentCategory;

        public ProductViewModel()
        {
            SelectedProduct = new();
        }

        private ProductDto? Product;
        public ProductDto SelectedProduct
        {
            get { return Product; }
            set
            {
                SetProperty(ref Product, value);
            }
        }

        [RelayCommand]
        private async Task AddProductAsync()
        {
            if (SelectedProduct.Name.IsNullOrEmpty() ||
                SelectedProduct.Firm.IsNullOrEmpty() ||
                SelectedProduct.Price.IsNullOrEmpty())
                return;

            if (SelectedCategory == null) { 
                MessageBox.Show("Необходимо выбрать категорию", "Предупреждение");
                return;
            }

            SelectedProduct.CategoryId = SelectedCategory.Id;

            SelectedProduct = await _productService.CreateAsync(SelectedProduct);

        }
    }
}
