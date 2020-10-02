using System.Threading.Tasks;

using MyProject.Roles;
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
        public DataSeedContributor(IGuidGenerator guidGenerator, IUserRepository appUsers, IRoleRepository appRoles, IStringEncryptionService stringEncryptionService)
        {
            _stringEncryptionService = stringEncryptionService;
            _guidGenerator = guidGenerator;
            _appUsers = appUsers;
            _appRoles = appRoles;
        }
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateRoleAsync();
            await GetUserAsync();
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
                await _appRoles.InsertAsync(new Role(_guidGenerator.Create(), roles[i]));
            }
        }

        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <returns></returns>
        private async Task GetUserAsync()
        {
            var user = new User(_guidGenerator.Create(), "admin", _stringEncryptionService.Encrypt("admin"), "admin", "1584329729@qq.com", "123456789", "admin");
            await _appUsers.InsertAsync(user);
        }
    }
}
