using InstaRent.Login.Helpers;
using InstaRent.Login.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace InstaRent.Login.Users
{
    public class UserDataSeedContributor: IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserDataSeedContributor( IUserRepository userRepository, IUnitOfWorkManager unitOfWorkManager)
        {
           
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userRepository.InsertAsync(new User
            (
                id: Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"),
                name: "Test Renter 1",
                email: "testrenter1@gmail.com",
                password: CryptoHelper.Encrypt("·VT)/CMy2XPg"),
                role: "Renter"
            ));


            await _userRepository.InsertAsync(new User
            (
                id: Guid.Parse("edba497f-ec22-4773-bd69-9188fe5e7933"),
                name: "Test Lessee 1",
                email: "testlesse1@gmail.com",
                password: CryptoHelper.Encrypt("dWKd1^24o@h2"),
                role: "Lessee"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}
