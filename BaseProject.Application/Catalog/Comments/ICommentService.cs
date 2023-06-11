using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Comments;
using BaseProject.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Comments
{
    public interface ICommentService
    {
        Task<ApiResult<bool>> Create(CommentCreateRequest request);

        Task<ApiResult<bool>> Update(int id, CommentCreateRequest request);

        Task<ApiResult<bool>> Delete(int id);
        Task<List<Comment>> GetById(int id);
        Task<int> CountAsyncById(int id);
        int CountById(int id);
        Task<List<CommentCreateRequest>> GetById2(int id);
    }
}
