using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.DTOs.Cart
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<CartDetailViewModel>? Details { get; set; }
        public decimal? TotalAmount
        {
            get
            {
                if (Details == null || Details.Count == 0)
                    return 0;
                return Details.Sum(x => (x.DiscountedPrice ?? 0) * (x.Quantity ?? 0));
            }
        }
    }
}
