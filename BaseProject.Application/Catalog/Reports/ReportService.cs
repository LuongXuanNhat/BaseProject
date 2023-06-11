using BaseProject.Application.Common;
using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Reports
{
    public class ReportService : IReportService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;


        public ReportService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<ApiResult<bool>> Create(Report request)
        {
            request.UserId = await _userService.GetIdByUserName(request.UserName);

            _context.Reports.Add(request);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<Report>>> GetAll(GetUserPagingRequest request)
        {
            var query = await _context.Reports.OrderByDescending(p => p.Id).ToListAsync();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Content.Contains(request.Keyword)).ToList();
            }

            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<Report>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<Report>>(pagedResult);
        }
    }
}
