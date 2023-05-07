using Azure.Core;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace BaseProject.ApiIntegration
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<bool>> DeleteCategory(CategoryDeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<CategoryRequest>> GetById(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/users/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<CategoryRequest>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<CategoryRequest>>(body);
        }

        public async Task<ApiResult<PagedResult<CategoryRequest>>> GetUsersPagings(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        
        public async Task<ApiResult<bool>> RegisterCategory(CategoryRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/categoriess", httpContent);

            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<bool>> UpdateCategory(CategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
