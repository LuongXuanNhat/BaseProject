using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Comments;
using BaseProject.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Comment
{
    public interface ICommentApiClient
    {
        Task<ApiResult<bool>> AddComment(CommentCreateRequest request);

        Task<ApiResult<bool>> UpdateComment(int commentId, CommentCreateRequest request);
        Task<ApiResult<bool>> DeleteComment(int commentId);
        Task<List<CommentCreateRequest>> GetById(int id);
    }
}
