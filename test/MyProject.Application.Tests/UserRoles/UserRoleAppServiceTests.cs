using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.UserRoles
{
    public class UserRoleAppServiceTests : MyProjectApplicationTestBase
    {
        private readonly IUserRoleAppService _userRoleAppService;

        public UserRoleAppServiceTests()
        {
            _userRoleAppService = GetRequiredService<IUserRoleAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
