using CommunityToolkit.Mvvm.Input;
using ExcellReports;
using InterfaceApplication.Models.Dto;
using InterfaceApplication.Services.Api;
using InterfaceApplication.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Windows;


namespace InterfaceApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CategoryViewModel categoryviewmodel { get; private set; }
        Task _currentTasck;
        CancellationToken _token;
        CancellationTokenSource _cancelTokenSource;

        private readonly CommonService<ProductDto, int> _productService = new("Product");


        public MainWindow()
        {   

            categoryviewmodel = App.HostContainer.Services.GetRequiredService<CategoryViewModel>();

            DataContext = categoryviewmodel;

            InitializeComponent();
            
        }

        [RelayCommand]

        private async Task CreatePriceListAsync()
        {
            //string baseDir = Environment.CurrentDirectory;
            Price_list price_list = new();

            var products = await _productService.GetAllAsync();

            string[,] data = new string[products.Count, 2];

            int row = 0;

            foreach (var product in products)
            {
                data[row, 0] = product.Name;
                data[row, 1] = product.Price;
                row++;
            }

            if (_currentTasck != null)
                _cancelTokenSource.Cancel();



            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;

            CreatePriceList.Visibility = Visibility.Hidden;

            _currentTasck = Task.Run(async () =>
            {
                price_list.CreateExcellDocument("B:\\Яндекс\\Саня\\Template.xlsx", data, "priceList");
                UpdateData();

            }, _token);

        }

        private void UpdateData()
        {
            Dispatcher.BeginInvoke(() => CreatePriceList.Visibility = Visibility.Visible);
        }

        private void CreatePriceList_Click(object sender, RoutedEventArgs e)
        {
            CreatePriceListAsync();
        }
    }
}
