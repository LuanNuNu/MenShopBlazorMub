using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Receipt.CreateReceipt;

namespace MenShopBlazor.Shared.Wrapper
{
    public class ReceiptDetailWrapper : CreateReceiptDetailDTO
    {
        public int? profitPercent { get; set; }
        public int? SelectedDetailId { get; set; }
        public int? QuantityInStock { get; set; } = 0;
        public IEnumerable<ProductDetailViewModel> FilteredProductDetails { get; set; } = new List<ProductDetailViewModel>();

    }
}
