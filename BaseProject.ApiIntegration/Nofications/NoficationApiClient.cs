using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Location;
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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BaseProject.ViewModels.Catalog.Post;
using System.Text.Json.Serialization;
using System.Text.Json;
using BaseProject.ViewModels.Catalog.Categories;

namespace BaseProject.ApiIntegration.Nofications
{
    public class NoficationApiClient : INoficationApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NoficationApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<List<NoticeDetail>>> GetNofiUser(string UserName)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/notifications/getall/{UserName}");

            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<List<NoticeDetail>>>(body);
            if (users.IsSuccessed)
                return users;
            return users;
        }
        public async Task<ApiResult<PagedResult<NoticeDetail>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/notifications/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&Keyword={request.Keyword}");

            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<NoticeDetail>>>(body);
            return users;
        }
    }
}
