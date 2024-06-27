using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {

        #region Category

        private CategoryInteractor CInteractor;

        public Category? selectedCategory;
        public Category? SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                SetProperty(ref selectedCategory, value);
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        #endregion

        private ProductIteractors PRinteractor;
        private ApplicationDbContext dbContext;
        public Category currentCategory;

        public ProductViewModel(ApplicationDbContext dbContext)
        {
            SelectedProduct = new();
            this.dbContext = dbContext;
            this.PRinteractor = new ProductIteractors(dbContext);
        }

        private Product? Product;
        public Product SelectedProduct
        {
            get { return Product; }
            set
            {
                SetProperty(ref Product, value);
            }
        }

        [RelayCommand]
        private void AddProduct()
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
            SelectedProduct = PRinteractor.CreateProduct(SelectedProduct);
        }
    }
}
