using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.DTOs.Order
{
    public class OrderProductDetailViewModel : ProductDetailBaseModel
    {
        public decimal? ShippingFee { get; set; }
    }
}
