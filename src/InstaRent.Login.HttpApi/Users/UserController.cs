using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace InstaRent.Login.Users
{
    [RemoteService(Name = "Login")]
    [Area("login")]
    [ControllerName("User")]
    [Route("api/user")]
    public class UserController : AbpController, IUserAppService
    {
        private readonly IUserAppService _appService;

        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserDto> GetAsync(Guid id)
        {
            return _appService.GetAsync(id);
        }

        [HttpPost]
        [Route("Login")]
        public virtual Task<UserDto> LoginAsync(LoginUserDto input)
        {
            return _appService.LoginAsync(input);
        }

        [HttpPost]
        [Route("Register")]
        public virtual Task<UserDto> CreateUserAsync(CreateUpdateUserDto input)
        {
            return _appService.CreateUserAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserDto> UpdateUserAsync(Guid id, CreateUpdateUserDto input)
        {
            return _appService.UpdateUserAsync(id, input);
        }

    }
}
