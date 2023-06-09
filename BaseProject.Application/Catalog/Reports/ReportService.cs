using BaseProject.Application.Common;
using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
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
    }
}
