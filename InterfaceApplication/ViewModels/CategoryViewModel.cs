using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InterfaceApplication.Views;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.ViewModels
{
    public partial class CategoryViewModel : ObservableObject
    {
        private EmployeeViewModel employeeViewModel;
        private CategoryViewModel categoryViewModel;
        private ProductIteractors PRinteractor;

        private CategoryInteractor CInteractor;
        private PurchaseOfGoodsIteractor PGInteractor;
        private PurchaseOfGoodaViewModel purchaseOfGoodaView;

      


        private readonly ApplicationDbContext dbContext;


        public Category selectedCategory;
        public Category SelectedCategory
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




        public string namecategory;
        public string description;


        public CategoryViewModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.employeeViewModel = new EmployeeViewModel(this.dbContext);

            this.categories = new List<Category>();
            this.products = new List<Product>();
            
            this.PRinteractor = new ProductIteractors(this.dbContext);
            this.CInteractor = new CategoryInteractor(this.dbContext);
            LoadProducts();
            LoadCategories();
        }
            
        [RelayCommand]
        private void LoadCategories()
        {
            Categories = CInteractor.GetAll().ToList();
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
      
        private PurchaseOfGoods? selectedPurchase = new();
        public PurchaseOfGoods? SelectedPurchase
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
            AddCategoryViewModel addcategoryViewModel=new(dbContext);
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
            AddCategoryViewModel addcategoryViewModel = new(dbContext);
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
                MessageBox.Show("Необходимо авторизоваться", "Предупреждение");
                return;
            }

            BasсketWindow basketWindow = new BasсketWindow();
            BascketViewModel bascketViewModel = new(dbContext, selectedEmployee);
            basketWindow.DataContext = bascketViewModel;
            basketWindow.ShowDialog();
        }



        [RelayCommand]
        private void AddToBascket()
        {
            if (SelectedEmployee == null) {
                MessageBox.Show("Необходимо авторизоваться", "Предупреждение");
                return;
            }
            if (SelectedProduct == null) return;

            AddToBascketWindow basketWindow = new AddToBascketWindow();
            AddToBascketViewModel addToBascketViewModel = new(dbContext);
            addToBascketViewModel.SelectedProduct=SelectedProduct;
            addToBascketViewModel.CurrentEmployee = selectedEmployee;
            basketWindow.DataContext = addToBascketViewModel;
            basketWindow.ShowDialog();
        }

        #region ProductCatalogViewModel

        private Product? NewProduct;

        private Product? selectedProduct;
        public Product? SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                SetProperty(ref selectedProduct, value);
            }
        }

        private List<Product> products;

        public List <Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        [RelayCommand]
        private void LoadProducts()
        {
            if (SelectedCategory != null)
            {
                Products = PRinteractor.GetAll().Where(p => p.CategoryId == SelectedCategory.Id).ToList();
            }
            else
            {
                Products = PRinteractor.GetAll().ToList();
            }
        }

        [RelayCommand]
        private void AddProduct()
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            ProductViewModel productViewModel = new ProductViewModel(dbContext);
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
            PRinteractor.RemoveProduct(SelectedProduct);
            LoadProducts();
        }

        #endregion
        #region EmployeeViewModel

        private Employee? selectedEmployee;
        public Employee? SelectedEmployee
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
            EmployeeViewModel employeeViewModel=new (dbContext);
            autoRegWindow.DataContext = employeeViewModel;
            autoRegWindow.ShowDialog();

            if (employeeViewModel.SelectedEmployee.NameEmployee.IsNullOrEmpty()
                || employeeViewModel.SelectedEmployee.Address.IsNullOrEmpty())
                 return;

            SelectedEmployee = new Employee()
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
