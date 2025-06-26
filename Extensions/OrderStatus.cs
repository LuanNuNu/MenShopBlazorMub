namespace MenShopBlazor.Extensions
{
    public enum OrderStatus
    {
        Created,//đơn hàng mới tạo
        Pending, //Chờ xác nhận
        Confirmed,//Đã xác nhận
        Cancelled,//Đã Hủy
        Paid, // đã thanh toán
        Delivering,//đang giao
        Completed, // Đã hoàn thành
        Returned // đã hoàn 
    }
}
