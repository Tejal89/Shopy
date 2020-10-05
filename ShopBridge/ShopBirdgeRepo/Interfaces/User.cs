using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(long UserId);
        void CreateUser(User User);
        void UpdateUser(User User);
        void DeleteUser(User User);
    }
}
