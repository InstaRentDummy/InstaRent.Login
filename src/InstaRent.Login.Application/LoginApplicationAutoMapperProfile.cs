using AutoMapper;
using InstaRent.Login.Users;
using Volo.Abp.AutoMapper;

namespace InstaRent.Login;

public class LoginApplicationAutoMapperProfile : Profile
{
    public LoginApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .Ignore(q => q.ExtraProperties)
            .Ignore(q => q.ConcurrencyStamp);

        //CreateMap<CreateUpdateUserDto, User>();
    }
}
