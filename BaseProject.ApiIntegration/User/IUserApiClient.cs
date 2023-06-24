using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.User
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<FollowerVm>>> GetFollowersPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> Register(RegisterRequestOfUser registerRequest);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);
        Task<ApiResult<UserVm>> GetByUserName(string username);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        Task<List<UserVm>> TakeByQuantity(int quantity);



        Task<ApiResult<bool>> AddFollow(FollowViewModel request);
        Task<ApiResult<bool>> UnFollow(FollowViewModel request);
        Task<ApiResult<bool>> CheckFollow(FollowViewModel request);
    }
}
