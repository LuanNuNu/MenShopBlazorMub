using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Newtonsoft.Json;
using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Account;
using MenShopBlazor.Shared;
using MenShopBlazor.Services.Admin;
using MenShopBlazor.Services.Token;
using System.Net.Http;
using System.Buffers.Text;
using System.Reflection;

public class AdminService : IAdminService
{
    private readonly HttpClient _httpClient;
    private const string baseUrl = "https://localhost:7094/api/Admin";
    private readonly ITokenService _tokenService;

    public AdminService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
    {
        _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        _tokenService = tokenService;
    }
    public async Task<ApiResponseModel<UserViewModel>> GetCurrentUserAsync()
    {
        return await HttpHelper.SendRequestAsync<UserViewModel>(async () =>
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/users/me");
            return response;
        });
    }

    public async Task<ApiResponseModel<object>> CreateUserAsync(AccountRegisterDTO model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PostAsync($"{baseUrl}/create-staff", content)
        );
    }

    public async Task<ApiResponseModel<IEnumerable<UserViewModel>>> GetUsersAsync(
        string? userId = null,
        string? email = null,
        string? roleId = null,
        int? branchId = null)
    {
        var query = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(userId))
            query.Add("userId", userId);

        if (!string.IsNullOrWhiteSpace(email))
            query.Add("email", email);

        if (!string.IsNullOrWhiteSpace(roleId))
            query.Add("roleId", roleId);

        if (branchId.HasValue)
            query.Add("branchId", branchId.Value.ToString());

        var url = QueryHelpers.AddQueryString($"{baseUrl}/users", query);

        return await HttpHelper.SendRequestAsync<IEnumerable<UserViewModel>>(() =>
            _httpClient.GetAsync(url)
        );
    }


    public async Task<ApiResponseModel<object>> UpdateEmployeeAsync(string id, EmployeeUpdateDTO model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PutAsync($"{baseUrl}/update-employee/{id}", content)
        );
    }
    public async Task<ApiResponseModel<object>> UpdateCustomerAsync(string id, CustomerUpdateDTO model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PutAsync($"{baseUrl}/update-customer/{id}", content)
        );
    }
    public async Task<ApiResponseModel<object>> UpdateOwnProfileAsync(CustomerUpdateDTO model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PutAsync($"{baseUrl}/update-profile", content)
        );
    }



    public async Task<ApiResponseModel<object>> AddClaimAsync(string userId, string claimType, string claimValue)
    {
        var payload = new
        {
            userId,
            claimType,
            claimValue
        };
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PostAsync($"{baseUrl}/add-claim", content)
        );
    }

    public async Task<ApiResponseModel<object>> ToggleUserStatusAsync(string userID)
    {
        var emptyContent = new StringContent("", Encoding.UTF8, "application/json");

        return await HttpHelper.SendRequestAsync<object>(() =>
            _httpClient.PutAsync($"{baseUrl}/toggle-user-status/{userID}", emptyContent)
        );
    }



    public async Task<ApiResponseModel<List<RoleDTO>>> GetRolesAsync()
    {
        return await HttpHelper.SendRequestAsync<List<RoleDTO>>(() =>
            _httpClient.GetAsync($"{baseUrl}/roles")
        );
    }


}
