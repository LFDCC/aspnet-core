using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using MyProject.Permissions;
using MyProject.Roles.Dtos;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.Roles
{
    [Authorize]
    public class RoleAppService : MyProjectAppService,
        IRoleAppService
    {
        //protected override string GetPolicyName { get; set; } = MyProjectPermissions.Role.Default;
        //protected override string GetListPolicyName { get; set; } = MyProjectPermissions.Role.Default;
        //protected override string CreatePolicyName { get; set; } = MyProjectPermissions.Role.Create;
        //protected override string UpdatePolicyName { get; set; } = MyProjectPermissions.Role.Update;
        //protected override string DeletePolicyName { get; set; } = MyProjectPermissions.Role.Delete;

        private readonly IRoleRepository _repository;

        public RoleAppService(IRoleRepository repository)
        {
            _repository = repository;
        }

    }
}
