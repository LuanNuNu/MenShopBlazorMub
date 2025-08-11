using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Order;
using MenShopBlazor.DTOs.Order.CreateOrder;
using MenShopBlazor.DTOs.Order.OrderReponse;
using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.Services.Order
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>?> GetAllOrdersAsync();
        Task<OrderViewModel?> GetOrderByIdAsync(string orderId);
        Task<List<OrderViewModel>?> GetOrdersByCustomerIdAsync(string customerId);
        Task<List<OrderViewModel>?> GetAllOnlineOrdersAsync();
        Task<List<OrderProductDetailViewModel>> GetOrderDetailAsync(string orderId);
        Task<ApiResponseModel<object>> CancelOrderAsync(string orderId, string reason);
        Task<OrderResponseDTO?> CreateOrderAsync(CreateOrderDTO createOrderDto);
        Task<List<OrderViewModel>?> SearchOrdersAsync(SearchOrderDTO search);
        Task<ApprovalResultDTO?> AutoApproveOrderAsync(string orderId);
        Task<ApprovalResultDTO?> AutoDecreaseStockOffline(string orderId);
        Task<List<OrderViewModel>?> GetPendingOrdersAsync();
        Task<ApiResponseModel<List<OrderViewModel>>> GetOrdersByDistrictAsync(string district);
        Task<ApiResponseModel<object>> UpdateOrderShipperStatusAsync(string orderId, string shipperId);
        Task<ApiResponseModel<object>> CompleteOrderAsync(string orderId);
        Task<List<OrderViewModel>?> GetOrdersByShipperIdAsync(string shipperId);
    }
}
