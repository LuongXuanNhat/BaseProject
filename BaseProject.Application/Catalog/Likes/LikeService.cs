using BaseProject.Application.Common;
using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Comments;
using BaseProject.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Likes
{
    public class LikeService : ILikeService
    {

        private readonly DataContext _context;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;

        public LikeService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
    
        public async Task<int> CountAsyncById(int id)
        {
            return await _context.Likes.Where(x => x.PostId == id).CountAsync();
        }
        public  int CountById(int id)
        {
            return  _context.Likes.Where(x => x.PostId == id).Count();
        }

     
    }
}
