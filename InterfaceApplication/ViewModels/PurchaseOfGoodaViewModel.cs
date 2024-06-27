using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using Ис_Мебельного_магазина;
using Ис_Мебельного_магазина.Domain.Interactors;
using Ис_Мебельного_магазина.Domain.Models;
namespace InterfaceApplication.ViewModels
{
    public partial class PurchaseOfGoodaViewModel
    {
        private PurchaseOfGoodsIteractor goodsIteractor;
        private ApplicationDbContext dbContext;
        private PurchaseOfGoods? NewPurchase;

        public PurchaseOfGoods? SelectedPurchase
        {
            get { return NewPurchase; }
            set
            {
              
            }
        }


        public PurchaseOfGoodaViewModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.goodsIteractor = new PurchaseOfGoodsIteractor(dbContext);
            SelectedPurchase = new PurchaseOfGoods();
        }


        [RelayCommand]
        private void AddProduct()
        {
            if  ( SelectedPurchase.PurchaseType.IsNullOrEmpty()
                || SelectedPurchase.PurchaseVolume.IsNullOrEmpty()
                || SelectedPurchase.PurchaseDescription.IsNullOrEmpty())
                return;

            SelectedPurchase = goodsIteractor.CreatePurchase(SelectedPurchase);

            if (SelectedPurchase == null)
            {
                MessageBox.Show("продукт не найден");
            }
            else
            {
                MessageBox.Show("продукт добавлен");
            }

        }

        //[RelayCommand]

        //private void Add(Window autorWindow)
        //{


        //}
    }
}
