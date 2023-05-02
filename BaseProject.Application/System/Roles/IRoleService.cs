
using BaseProject.ViewModels.System.Roles;

namespace BaseProject.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
