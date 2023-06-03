using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Search;
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

namespace BaseProject.ApiIntegration.Searchs
{
    public class SearchApiClient : ISearchApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SearchApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<ApiResult<PagedResult<SearchVm>>> GetAllByUserName(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/searchs/history/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&Keyword={request.Keyword}");

            var body = await response.Content.ReadAsStringAsync();
            var history = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<SearchVm>>>(body);
            return history;
        }

        public Task<ApiResult<SearchVm>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
