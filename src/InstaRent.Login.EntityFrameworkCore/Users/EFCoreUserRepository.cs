using InstaRent.Login.EntityFrameworkCore;
using InstaRent.Login.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Login.Users
{
    public class EFCoreUserRepository : EfCoreRepository<LoginDbContext, User, Guid>, IUserRepository
    {
        public EFCoreUserRepository(IDbContextProvider<LoginDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<User> GetByAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                       .FirstOrDefaultAsync(q => q.Id == id,
                           cancellationToken: GetCancellationToken(cancellationToken))
                   ?? throw new EntityNotFoundException(typeof(User)); //TODO: Maybe create new exception with property extending this
        }

        public async Task<User> LoginAsync(string email, string password,
            CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                       .FirstOrDefaultAsync(q => q.Email == email && q.Password == CryptoHelper.Encrypt(password),
                           cancellationToken: GetCancellationToken(cancellationToken))
                   ?? throw new EntityNotFoundException(typeof(User)); //TODO: Maybe create new exception with property extending this
        }

    }
}
