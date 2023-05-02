
using BaseProject.ViewModels.System.Roles;

namespace BaseProject.Application.System.Roles
{
    public interface IRoleService
    {
        public interface IUserService
        {
            Task<List<RoleVm>> GetAll();
        }
    }
}
