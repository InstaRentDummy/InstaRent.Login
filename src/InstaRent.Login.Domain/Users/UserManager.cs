using InstaRent.Login.Helpers;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace InstaRent.Login.Users
{
    public class UserManager : DomainService
    {
        private readonly IUserRepository _repository;
        //private readonly IDistributedEventBus _distributedEventBus;

        public UserManager(
            IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> CreateUserAsync(
            string name,
            string email,
            string password,
            string role
        )
        {
            // Create new user
            User user = new User(
                id: GuidGenerator.Create(),
                name: name,
                    email: email,
                    password: CryptoHelper.Encrypt(password),
                    role: role);

            var result = await _repository.InsertAsync(user, true);

            return result;
        }

        public async Task<User> UpdateUserAsync(
            Guid id,
            string name,
            string email,
            string password,
            string role
        )
        {
            var user = await _repository.GetAsync(id);
            user.Name = name;
            user.Email = email;
            user.Password = CryptoHelper.Encrypt(password);
            user.Role = role;

            var result = await _repository.UpdateAsync(user, true);

            return result;
        }

    }
}
