using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.AddressDTO;
using MenShopBlazor.DTOs.Color;
using MenShopBlazor.Services.CustomerAddress;
using MenShopBlazor.Shared;
using Newtonsoft.Json;
using System.Text;

public class CustomerAddressService : ICustomerAddressService
{
    private readonly HttpClient _httpClient;
    private const string baseUrl = "https://localhost:7094/api/CustomerAddress";

    public CustomerAddressService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    }

    public async Task<List<CustomerAddressViewModel>> GetAllAsync()
    {
        var result = await HttpHelper.SendRequestAsync<List<CustomerAddressViewModel>>(() =>
            _httpClient.GetAsync($"{baseUrl}")
        );
        return result.Data ?? new List<CustomerAddressViewModel>();
    }

    public async Task<List<CustomerAddressViewModel>> GetByCustomerIdAsync(string customerId)
    {
        var result = await HttpHelper.SendRequestAsync<List<CustomerAddressViewModel>>(() =>
            _httpClient.GetAsync($"{baseUrl}/customer/{customerId}")
        );
        return result.Data ?? new List<CustomerAddressViewModel>();
    }

    public async Task<ApiResponseModel<object>> CreateAsync(CreateUpdateCustomerAddressDTO dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PostAsync($"{baseUrl}", content)
        );
    }

    public async Task<ApiResponseModel<object>> UpdateAsync(int id, CreateUpdateCustomerAddressDTO dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PutAsync($"{baseUrl}/{id}", content) 
        );
    }


    public async Task<ApiResponseModel<object>> DeleteAsync(int id)
    {
        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.DeleteAsync($"{baseUrl}/{id}")
        );
    }
}
