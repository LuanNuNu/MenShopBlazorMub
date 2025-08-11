using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.AddressDTO
{
    public class CustomerAddressViewModel : BaseCustomerAddressDTO
    {
        public string? CustomerName { get; set; }
        public string FullAddress => $"{Street}, {WardName}, {DistrictName}, {ProvinceName}";
    }
}
