using System.Linq;
using System.Threading.Tasks;

using MyProject.Roles;
using MyProject.UserRoles;
using MyProject.Users;

using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Security.Encryption;
using Volo.Abp.Uow;

namespace MyProject.DataSeed
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IStringEncryptionService _stringEncryptionService;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IUserRepository _appUsers;
        private readonly IRoleRepository _appRoles;
        private readonly IUserRoleRepository _appUserRoles;
        public DataSeedContributor(IGuidGenerator guidGenerator, IUserRepository appUsers, IRoleRepository appRoles, IUserRoleRepository appUserRoles, IStringEncryptionService stringEncryptionService)
        {
            _stringEncryptionService = stringEncryptionService;
            _guidGenerator = guidGenerator;
            _appUsers = appUsers;
            _appRoles = appRoles;
            _appUserRoles = appUserRoles;
        }
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateRoleAsync();
            await CreateUserAsync();
            await CreateUserRoleAsync();
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <returns></returns>
        private async Task CreateRoleAsync()
        {
            var roles = new[] {
                "admin",
                "teacher",
                "student"
            };
            for (int i = 0; i < roles.Length; i++)
            {
                await _appRoles.InsertAsync(entity: new Role(_guidGenerator.Create(), roles[i]), autoSave: true);
            }
        }

        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <returns></returns>
        private async Task CreateUserAsync()
        {
            var user = new User(_guidGenerator.Create(), "admin", _stringEncryptionService.Encrypt("admin"), "admin", "1584329729@qq.com", "123456789");
            await _appUsers.InsertAsync(entity: user, autoSave: true);
        }

        /// <summary>
        /// 初始化用户角色
        /// </summary>
        /// <returns></returns>
        private async Task CreateUserRoleAsync()
        {
            var roles = await _appRoles.GetListAsync();
            var user = await _appUsers.FindAsync(r => r.UserName == "admin");
            foreach (var role in roles)
            {
                await _appUserRoles.InsertAsync(new UserRole(user.Id, role.Id));
            }
        }
    }
}
