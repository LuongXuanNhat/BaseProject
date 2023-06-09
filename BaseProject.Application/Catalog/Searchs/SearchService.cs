using Azure.Core;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using BaseProject.ViewModels.Catalog.Search;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Catalog.Search;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseProject.Application.System.Users;

namespace BaseProject.Application.Catalog.Searchs
{
    public class SearchService : ISearchService
    {

        private readonly DataContext _context;
        private readonly IUserService _userService;


        public SearchService(DataContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;

        }

        public async Task<ApiResult<bool>> Add(Guid UserId, List<string> Content)
        {
            if (Content == null)
            {
                return new ApiErrorResult<bool>();
            } else
            {
                Search search = new Search();

                search.UserId = UserId;
                search.Date = DateTime.Now;

                if (Content.Count == 1)
                {
                    search.Content = Content[0];
                }
                else
                {
                    search.Content = Content[1] + " : " + Content[0];
                }

                _context.Searches.Add(search);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }   
        }

        public async Task<ApiResult<bool>> Delete(string usename)
        {
            var UserId = await _userService.GetIdByUserName(usename);

            var query = await _context.Searches.Where(x => x.UserId == UserId).ToListAsync();


            _context.Searches.RemoveRange(query);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<SearchVm>>> GetAllSearchHistoryPaging(GetUserPagingRequest request)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x=>x.UserName.Equals(request.Keyword));
            
            // Lấy danh sách lịch sử tìm kiếm của user
            var query = await _context.Searches.OrderByDescending(x => x.Date).Where(x=>x.UserId == getUser.Id).ToListAsync();

            // Gộp nhóm user theo ngày:
                // Lấy số ngày khác nhau:
                var getDate = query.Select(x => x.Date.Date).Distinct().ToList();
                // Khởi tạo SearchVm List
                List<SearchVm> result = new List<SearchVm>();


            // Lọc danh sách nội dung tìm kiếm theo ngày:
            foreach (var item in getDate)
            {
                SearchVm vm = new SearchVm();
                var listForDate = query.Where(x => x.Date.Date.Equals(item.Date)).ToList();
                vm.UserId = getUser.Id;
                vm.Date = item.Date;
                vm.Content = listForDate.Select(x => x.Content).ToList();

                result.Add(vm);

            }
                

            //3. Paging
            int totalRow = result.Count();

            var data = result.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<SearchVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<SearchVm>>(pagedResult);
        }
    }
}
