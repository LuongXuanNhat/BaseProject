using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.RatingStar;
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
using BaseProject.ViewModels.System.Users;

namespace BaseProject.ApiIntegration.RatingStars
{
    public class RatingApiClient : IRatingApiClient
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RatingApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RatingLocationDetailVm>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<RatingLocationDetailVm>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PagedResult<RatingLocationDetailVm>>> GetByUserName(GetUserPagingRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/rating/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&Keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<RatingLocationDetailVm>>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<RatingLocationDetailVm>>>(body);
        }

        public async Task<ApiResult<bool>> Rating(int id, int stars)
        {
            throw new NotImplementedException();
        }
    }
}
