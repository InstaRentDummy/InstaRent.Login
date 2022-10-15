using AutoMapper.Internal.Mappers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace InstaRent.Login.Users
{
    public class UserAppServiceTests: LoginApplicationTestBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IRepository<User,Guid> _userRepository;

        public UserAppServiceTests()
        {
            _userAppService=GetRequiredService<IUserAppService>();
            _userRepository=GetRequiredService<IRepository<User,Guid>>();
        }
        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userAppService.GetAsync(Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"));
        }
        [Fact]
        public async Task LoginLesseeAsync()
        {
            var result = await _userAppService.LoginAsync(new LoginUserDto()
            {
                Email = "testlesse1@gmail.com",
                Password = "dWKd1^24o@h2"
            }
                );

            result.ShouldNotBeNull();
            result.Role.ShouldBe("Lessee");

        }

        [Fact]
        public async Task LoginRenterAsync()
        {
            var result = await _userAppService.LoginAsync(new LoginUserDto()
            {
                Email = "testrenter1@gmail.com",
                Password = "·VT)/CMy2XPg"
            }
                );

            result.ShouldNotBeNull();
            result.Role.ShouldBe("Renter");

        }

        [Fact]
        public async Task FailLoginRenterAsync()
        {
           await Assert.ThrowsAsync<EntityNotFoundException>(() => _userAppService.LoginAsync(new LoginUserDto()
            {
                Email = "testrenter1@gmail.com",
                Password = "Fail$Pwd01"
            }
                ));
        }

        [Fact]
        public async Task ChangePasswordAsync()
        {
            var result = await _userAppService.GetAsync(Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"));

            var changeresult = await _userAppService.UpdateUserAsync(Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765")
                , new CreateUpdateUserDto()
                {
                    Name = result.Name,
                    Email = result.Email,
                    Password = "ChngPa$$w0rd",
                    Role = result.Role
                }
                );

            changeresult.ShouldNotBeNull();
            changeresult.Password.ShouldBe("ChngPa$$w0rd");

        }

        [Fact]
        public async Task CreateUserAsync()
        {

            var result = await _userAppService.CreateUserAsync( new CreateUpdateUserDto()
                {
                    Name = "New User",
                    Email = "newemail@gmail.com",
                    Password = "NewPa$$w0rd",
                    Role = "Lessee"
                }
                );

            result.ShouldNotBeNull();
            
        }
    }
}
