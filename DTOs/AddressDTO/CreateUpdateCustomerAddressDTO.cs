using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.AddressDTO
{
    public class CreateUpdateCustomerAddressDTO : BaseCustomerAddressDTO
    {
        public string? CustomerId { get; set; }
    }
}
