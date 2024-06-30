using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExcellReports;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using InterfaceApplication.Views;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class CategoryViewModel : ObservableObject
    {

        private readonly EmployeeViewModel employeeViewModel;

        private readonly CommonService<ProductDto, int> _productService = new("Product");
        private readonly CommonService<CategoryDto, int> _categoryService = new("Category");

        public CategoryDto selectedCategory;
        public CategoryDto SelectedCategory
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

        public string namecategory;
        public string description;


        public CategoryViewModel()
        {
            this.employeeViewModel = new EmployeeViewModel();

            this.categories = [];
            this.products = [];


            _productService = new("Product");
            _categoryService = new("Category");

            LoadProducts();
            LoadCategories();
        }
            
        [RelayCommand]
        private async void LoadCategories()
        {
            Categories = await _categoryService.GetAllAsync();
        }


        [RelayCommand]
        private void MouseDoubleClick(System.Windows.Controls.ListBox listBox)
        {
            AddToBascket();
        }

        [RelayCommand]
        private void CategoriesSelectedChanged()
        {
            LoadProducts();
        }
      
        private Purchase? selectedPurchase = new();
        public Purchase? SelectedPurchase
        {
            get { return selectedPurchase; }
            set
            {
                SetProperty(ref selectedPurchase, value);
            }
        }

        #region CategoryViewModel

        [RelayCommand]
        private void AddCategory()
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            AddCategoryViewModel addcategoryViewModel=new();
            addCategoryWindow.DataContext = addcategoryViewModel;
            addCategoryWindow.ShowDialog();

            if (addcategoryViewModel.SelectedCategory == null)
                return;

            LoadCategories();
        }

        [RelayCommand]
        private void AddsCategories(Category category)
        {

            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            AddCategoryViewModel addcategoryViewModel = new();
            addCategoryWindow.DataContext = addcategoryViewModel;
            addCategoryWindow.ShowDialog();

            if (addcategoryViewModel.SelectedCategory== null)
                return;

            

            LoadCategories();
        }
        #endregion

        [RelayCommand]
        private void OpenBascket()
        {
            if (SelectedEmployee == null)
            {
                System.Windows.MessageBox.Show("Необходимо авторизоваться", "Предупреждение");
                return;
            }

            BasсketWindow basketWindow = new BasсketWindow();
            BascketViewModel bascketViewModel = new(selectedEmployee);
            basketWindow.DataContext = bascketViewModel;
            basketWindow.ShowDialog();
        }



        [RelayCommand]
        private void AddToBascket()
        {
            if (SelectedEmployee == null) {
                System.Windows.MessageBox.Show("Необходимо авторизоваться", "Предупреждение");
                return;
            }
            if (SelectedProduct == null) return;

            AddToBascketWindow basketWindow = new AddToBascketWindow();
            AddToBascketViewModel addToBascketViewModel = new();
            addToBascketViewModel.SelectedProduct=SelectedProduct;
            addToBascketViewModel.CurrentEmployee = selectedEmployee;
            basketWindow.DataContext = addToBascketViewModel;
            basketWindow.ShowDialog();
        }

        #region ProductCatalogViewModel

        private ProductDto? selectedProduct;
        public ProductDto? SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                SetProperty(ref selectedProduct, value);
            }
        }

        private List<ProductDto> products;

        public List <ProductDto> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        [RelayCommand]
        private async void LoadProducts()
        {
            if (SelectedCategory != null)
            {
                Products = await _productService.GetAllAsync();
                Products= Products.Where(p => p.CategoryId == SelectedCategory.Id).ToList();
            }
            else
            {
                Products = await _productService.GetAllAsync();
            }
        }

        [RelayCommand]
        private void AddProduct()
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            ProductViewModel productViewModel = new ProductViewModel();
            addProductWindow.DataContext = productViewModel;
            productViewModel.Categories = Categories;
            productViewModel.SelectedCategory = selectedCategory;
            addProductWindow.ShowDialog();

            if (productViewModel.SelectedProduct==null)
                return;

            LoadProducts();           
        }

        [RelayCommand]
        private void RemoveProduct()
        {
            if (SelectedProduct == null) return;
            _productService.DeleteAsync(SelectedProduct.Id);
            LoadProducts();
        }

        #endregion
        #region EmployeeViewModel

        private EmployeeDto? selectedEmployee;
        public EmployeeDto? SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                SetProperty(ref selectedEmployee, value);
            }
        }


        [RelayCommand]
        private void AddEmployees()
        {
            AutorizationWindow employeeWindow = new AutorizationWindow();
            employeeWindow.DataContext = employeeViewModel;
            employeeWindow.ShowDialog();

        }


        [RelayCommand]

        private void RegEmployies(StackPanel AdminPanel)
        {

            RegistrationWindow autoRegWindow = new RegistrationWindow();
            EmployeeViewModel employeeViewModel=new ();
            autoRegWindow.DataContext = employeeViewModel;
            autoRegWindow.ShowDialog();

            if (employeeViewModel.SelectedEmployee.NameEmployee.IsNullOrEmpty()
                || employeeViewModel.SelectedEmployee.Address.IsNullOrEmpty())
                 return;

            SelectedEmployee = new EmployeeDto()
            {
                NameEmployee = employeeViewModel.SelectedEmployee.NameEmployee,
                Address = employeeViewModel.SelectedEmployee.Address,
                Id = employeeViewModel.SelectedEmployee.Id,
                Status = employeeViewModel.SelectedEmployee.Status,
            };

            if (SelectedEmployee.Status == "Admin")
            {
                AdminPanel.Visibility=Visibility.Visible;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
    }
}
