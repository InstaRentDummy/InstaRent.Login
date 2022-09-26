using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace InstaRent.Login.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly UserManager _manager;
        private readonly IUserRepository _repository;

        public UserAppService(UserManager manager,
            IUserRepository repository
        )
        {
            _manager = manager;
            _repository = repository;
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);
            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> LoginAsync(LoginUserDto input)
        {
            var user = await _repository.LoginAsync(input.Email, input.Password);
            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUpdateUserDto input)
        {
            var user = await _manager.CreateUserAsync
            (
                name: input.Name,
                email: input.Email,
                password: input.Password,
                role: input.Role
            );

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(Guid id, CreateUpdateUserDto input)
        {
            var user = await _manager.UpdateUserAsync
            (
                id: id,
                name: input.Name,
                email: input.Email,
                password: input.Password,
                role: input.Role
            );

            return ObjectMapper.Map<User, UserDto>(user);
        }

    }
}
