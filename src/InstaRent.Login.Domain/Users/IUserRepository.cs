using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace InstaRent.Login.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetByAsync(Guid id,
            CancellationToken cancellationToken = default);

        Task<User> LoginAsync(string email, string password,
            CancellationToken cancellationToken = default);
    }
}
