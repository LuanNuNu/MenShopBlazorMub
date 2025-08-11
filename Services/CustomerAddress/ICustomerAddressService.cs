using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.AddressDTO;

namespace MenShopBlazor.Services.CustomerAddress
{
    public interface ICustomerAddressService
    {         
        Task<List<CustomerAddressViewModel>> GetAllAsync();
        Task<List<CustomerAddressViewModel>> GetByCustomerIdAsync(string customerId);
        Task<ApiResponseModel<object>> CreateAsync(CreateUpdateCustomerAddressDTO dto);
        Task<ApiResponseModel<object>> UpdateAsync(int id, CreateUpdateCustomerAddressDTO dto);
        Task<ApiResponseModel<object>> DeleteAsync(int id);
    }
}
