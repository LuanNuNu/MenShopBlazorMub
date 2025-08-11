namespace MenShopBlazor.DTOs.AddressDTO
{
    public class BaseCustomerAddressDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        public int WardId { get; set; }
        public string WardName { get; set; }

    }
}
