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

namespace BaseProject.Application.Catalog.Comments
{
    public class CommentService : ICommentService
    {

        private readonly DataContext _context;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;

        public CommentService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<ApiResult<bool>> Create(CommentCreateRequest request)
        {
            Guid userId = await _userService.GetIdByUserName(request.UserName);
            var comment = new Comment();
            comment.UserId = userId;
            comment.PostId = request.PostId ?? 0;
            comment.PreCommentId = request.PreCommentId ?? 0;
            comment.Date = DateTime.Now;
            comment.Content = request.Content;
            comment.Like = 0;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x=>x.Id == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<List<Comment>> GetById(int id)
        {
            return await _context.Comments.Where(x => x.PostId == id).ToListAsync();
        }
        public async Task<int> CountAsyncById(int id)
        {
            return await _context.Comments.Where(x => x.PostId == id).CountAsync();
        }
        public  int CountById(int id)
        {
            return  _context.Comments.Where(x => x.PostId == id).Count();
        }

        public async Task<List<CommentCreateRequest>> GetById2(int id)
        {
            var comments = await _context.Comments.OrderByDescending(x => x.Date).Where(x => x.PostId == id).ToListAsync();
            List<CommentCreateRequest> comment = new List<CommentCreateRequest>();

            foreach (var item in comments)
            {
                var obj = new CommentCreateRequest();
                obj.PostId = item.PostId;
                obj.Id = item.Id;
                obj.UserId = item.UserId;
                obj.UserName = await _userService.GetUserNameByIdAsync(item.UserId);
                obj.Date = item.Date;
                obj.Content = item.Content;
                obj.PreCommentId = item.PreCommentId;

                comment.Add(obj);
            }

            return comment;
        }

        public async Task<ApiResult<bool>> Update(int id, CommentCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
