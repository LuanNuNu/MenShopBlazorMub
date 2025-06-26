namespace MenShopBlazor.Extensions
{
	public enum PaymentStatus
	{
		Pending,            // Chờ xử lý
		Processing,         // Đang xử lý
		Completed,          // Hoàn thành
		Failed,             // Thất bại
		Refunded,           // Đã hoàn tiền
		PartiallyRefunded   // Hoàn tiền một phần
	}
}
