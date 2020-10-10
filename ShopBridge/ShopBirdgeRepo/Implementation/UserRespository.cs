using Microsoft.EntityFrameworkCore;
using ShopBridgeData.DataContext;
using ShopBridgeData.Entity;
using ShopBridgeRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ShopBridgeContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll()
               .OrderByDescending(x=> x.UserId)
               .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(long UserId)
        {
            return await FindByCondition(x => x.UserId.Equals(UserId))
                .FirstOrDefaultAsync();
        }
        
        public async Task<int> CreateUser(User User)
        {
            return await Create(User);
        }
        public async Task<int> UpdateUser(User User)
        {
            return await Update(User);
        }
        public async Task<int> DeleteUser(User User)
        {
            return await Delete(User);
        }
    }
}
