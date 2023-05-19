
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Location;

namespace BaseProject.ApiIntegration.Locations
{
    public class LocationApiClient : ILocationApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> Delete(int locationId)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/locations/{locationId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<LocationCreateRequest>> GetById(int locationId)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/locations/{locationId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<LocationCreateRequest>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<LocationCreateRequest>>(body);
        }

        public async Task<ApiResult<PagedResult<LocationCreateRequest>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/locations/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&Keyword={request.Keyword}");

            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<LocationCreateRequest>>>(body);
            return users;
        }


        public async Task<ApiResult<bool>> RegisterOrUpdate(LocationCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);


            var requestContent = new MultipartFormDataContent();

            if (request.GetImage != null)
            {
                byte[] data;
                for (int i = 0; i < request.GetImage.Count; i++)
                {
                    using (var br = new BinaryReader(request.GetImage[i].OpenReadStream()))
                    {
                        data = br.ReadBytes((int)request.GetImage[i].OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "GetImage", request.GetImage[i].FileName);
                }
                requestContent.Add(new StringContent(request.Name.ToString()), "Name");
                requestContent.Add(new StringContent(request.Address.ToString()), "Address");
                requestContent.Add(new StringContent(string.IsNullOrEmpty(request.LocationId.ToString()) ? "" : request.LocationId.ToString()), "LocationId");

            }

            var response = await client.PostAsync($"/api/locations/", requestContent);

            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<bool>> Update(LocationCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/locations/", httpContent);

            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }
    }
}
