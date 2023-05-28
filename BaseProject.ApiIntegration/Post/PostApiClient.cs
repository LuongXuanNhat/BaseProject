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
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.Data.Entities;
using Microsoft.SqlServer.Server;

namespace BaseProject.ApiIntegration.Post
{
    public class PostApiClient : IPostApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> CreateOrUpdatePost(PostCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            
            requestContent.Add(new StringContent(request.PostId.ToString()), "PostId");
            requestContent.Add(new StringContent(request.UserId), "UserId");
            requestContent.Add(new StringContent(request.Title), "Title");
            requestContent.Add(new StringContent(request.numberLocation.ToString()), "NumberLocation");

            // Thêm các thuộc tính khác của PostDetail
            foreach (var postDetail in request.PostDetail)
            {
                requestContent.Add(new StringContent(postDetail.Title), $"PostDetail[{request.PostDetail.IndexOf(postDetail)}].Title");
                requestContent.Add(new StringContent(postDetail.Address), $"PostDetail[{request.PostDetail.IndexOf(postDetail)}].Address");
                requestContent.Add(new StringContent(postDetail.Content), $"PostDetail[{request.PostDetail.IndexOf(postDetail)}].Content");
                requestContent.Add(new StringContent(postDetail.postDetailId.ToString()), $"PostDetail[{request.PostDetail.IndexOf(postDetail)}].postDetailId");
                requestContent.Add(new StringContent(postDetail.When.ToString("MM-yyyy")), $"PostDetail[{request.PostDetail.IndexOf(postDetail)}].When");
            
                if (postDetail.GetImage != null )
                {
                    byte[] data;
                    for (int i = 0; i < postDetail.GetImage.Count; i++)
                    {
                        using (var br = new BinaryReader(postDetail.GetImage[i].OpenReadStream()))
                        {
                            data = br.ReadBytes((int)postDetail.GetImage[i].OpenReadStream().Length);
                        }
                        ByteArrayContent bytes = new ByteArrayContent(data); 
                        requestContent.Add(bytes, $"PostDetail[{request.PostDetail.IndexOf(postDetail)}].GetImage", postDetail.GetImage[i].FileName);
                        
                    }
                }

            }

            if (request.CategoryPostDetail != null && request.CategoryPostDetail.Count != 0)
            {
                foreach (var categoryDetail in request.CategoryPostDetail)
                {
                    requestContent.Add(new StringContent(categoryDetail.CategoriesId.ToString()), $"CategoryPostDetail[{request.CategoryPostDetail.IndexOf(categoryDetail)}].CategoriesId");
                    requestContent.Add(new StringContent(categoryDetail.Name), $"CategoryPostDetail[{request.CategoryPostDetail.IndexOf(categoryDetail)}].Name");
                }
            }

            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await client.PostAsync($"/api/post", requestContent);

            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }


        // Không dùng
        public async Task<ApiResult<bool>> DeleteCategory(int idCategory)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/categoriess/{idCategory}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public Task<ApiResult<bool>> DeletePost(int idCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> GetAll()
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync("/api/post/Find");
            var body = await response.Content.ReadAsStringAsync();
            List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(body);

            return locations;
            //return JsonConvert.DeserializeObject<List<Location>>(body);
            //return JsonConvert.DeserializeObject<List<Location>>(body);
        }

        public async Task<ApiResult<PostCreateRequest>> GetById(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/post/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PostCreateRequest>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<PostCreateRequest>>(body);
        }

        public async Task<ApiResult<PagedResult<PostVm>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/post/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&Keyword={request.Keyword}&UserName={request.UserName}");

            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<PostVm>>>(body);
            return users;
        }
        public async Task<ApiResult<PagedResult<PostVm>>> GetAllPostPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/post/pagingall?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&Keyword={request.Keyword}");

            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<PostVm>>>(body);
            return users;
        }

        public async Task<ApiResult<bool>> UpdatePost(int idPost, PostCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/post/{idPost}", httpContent);

            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }
    }
}
