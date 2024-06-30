using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.Models.Dto
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int PurchasePrise { get; set; }
        public string PurchaseVolume { get; set; }
        public string PurchaseType { get; set; }
        public string PurchaseDescription { get; set; }

        public PurchaseDto() { }

        public PurchaseDto(int id, int purchasePrise, string purchaseVolume, string purchaseType, string purchaseDescription)
        {
            Id = id;
            PurchasePrise = purchasePrise;
            PurchaseVolume = purchaseVolume;
            PurchaseType = purchaseType;
            PurchaseDescription = purchaseDescription;
        }
        public PurchaseDto(Purchase purchase)
        {
            this.Id = purchase.Id;
            this.PurchasePrise = purchase.PurchasePrise;
            this.PurchaseDescription = purchase.PurchaseDescription;
            this.PurchaseVolume = purchase.PurchaseVolume;
            this.PurchaseType = purchase.PurchaseType;

        }
    }
}
