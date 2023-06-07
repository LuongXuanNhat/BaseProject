using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.System.Users;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.FavoriteSave;

namespace BaseProject.ApiIntegration.Saves
{
    public class SaveApiClient : ISaveApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaveApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<ApiResult<bool>> AddToArchive(AddSaveVm request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);


            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/saves/", httpContent);

            var body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
            }
            return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);


        }

        public async Task<ApiResult<bool>> Check(AddSaveVm request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/saves/check?Username={request.Username}&Id={request.Id}&number={request.number}");

            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return new ApiSuccessResult<bool>();
            return new ApiErrorResult<bool>();
        }

        public async Task<ApiResult<PagedResult<LocationVm>>> GetByUserName(GetUserPagingRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/saves/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&UserName={request.UserName}&number={request.number}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<LocationVm>>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<LocationVm>>>(body);
        }
    }
}
