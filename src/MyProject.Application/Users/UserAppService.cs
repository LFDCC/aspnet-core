using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyProject.Permissions;
using MyProject.Users.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Encryption;

namespace MyProject.Users
{
    public class UserAppService : CrudAppService<User, UserDto, Guid, PagedAndSortedResultRequestDto, CreateUserDto, UpdateUserDto>,
        IUserAppService
    {
        protected override string GetPolicyName { get; set; } = MyProjectPermissions.User.Default;
        protected override string GetListPolicyName { get; set; } = MyProjectPermissions.User.Default;
        protected override string CreatePolicyName { get; set; } = MyProjectPermissions.User.Create;
        protected override string UpdatePolicyName { get; set; } = MyProjectPermissions.User.Update;
        protected override string DeletePolicyName { get; set; } = MyProjectPermissions.User.Delete;

        private readonly IUserRepository _repository;
        private readonly IStringEncryptionService _stringEncryptionService;


        public UserAppService(IUserRepository repository, IStringEncryptionService stringEncryptionService) : base(repository)
        {
            _repository = repository;
            _stringEncryptionService = stringEncryptionService;
        }

        [RemoteService(false)]
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var password = _stringEncryptionService.Encrypt(loginDto.PassWord);
            var user = await _repository.GetAsync(t => t.UserName == loginDto.UserName && t.PassWord == password);

            return ObjectMapper.Map<User, UserDto>(user);
        }
    }
}
