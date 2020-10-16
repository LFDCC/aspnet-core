using System;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Permissions;
using MyProject.UserRoles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.UserRoles
{
    public class UserRoleAppService : AbstractKeyCrudAppService<UserRole, UserRoleDto, UserRoleKey, PagedAndSortedResultRequestDto, CreateUserRoleDto, UpdateUserRoleDto>,
        IUserRoleAppService
    {
        protected override string GetPolicyName { get; set; } = MyProjectPermissions.UserRole.Default;
        protected override string GetListPolicyName { get; set; } = MyProjectPermissions.UserRole.Default;
        protected override string CreatePolicyName { get; set; } = MyProjectPermissions.UserRole.Create;
        protected override string UpdatePolicyName { get; set; } = MyProjectPermissions.UserRole.Update;
        protected override string DeletePolicyName { get; set; } = MyProjectPermissions.UserRole.Delete;

        private readonly IUserRoleRepository _repository;
        
        public UserRoleAppService(IUserRoleRepository repository) : base(repository)
        {
            _repository = repository;
        }
        
        protected override Task DeleteByIdAsync(UserRoleKey id)
        {
            // TODO: AbpHelper generated
            return _repository.DeleteAsync(e =>
                e.UserId == id.UserId &&
                e.RoleId == id.RoleId
            );
        }

        protected override async Task<UserRole> GetEntityByIdAsync(UserRoleKey id)
        {
            // TODO: AbpHelper generated
            return await AsyncExecuter.FirstOrDefaultAsync(
                _repository.Where(e =>
                    e.UserId == id.UserId &&
                    e.RoleId == id.RoleId
                )
            ); 
        }
    }
}
