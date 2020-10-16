using System;
using System.Threading.Tasks;
using MyProject.UserRoles;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MyProject.EntityFrameworkCore.UserRoles
{
    public class UserRoleRepositoryTests : MyProjectEntityFrameworkCoreTestBase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleRepositoryTests()
        {
            _userRoleRepository = GetRequiredService<IUserRoleRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
