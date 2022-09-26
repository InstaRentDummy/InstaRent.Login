using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace InstaRent.Login.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserDto> GetAsync(Guid id);

        Task<UserDto> LoginAsync(LoginUserDto input);

        Task<UserDto> CreateUserAsync(CreateUpdateUserDto input);

        Task<UserDto> UpdateUserAsync(Guid id, CreateUpdateUserDto input);

    }
}
