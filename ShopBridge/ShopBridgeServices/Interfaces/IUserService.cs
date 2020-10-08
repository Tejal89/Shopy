using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeServices.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(long UserId);
        Task<User> CreateUser(User User);
        Task<User> UpdateUser(User User);
        void DeleteUser(User User);
    }
}
