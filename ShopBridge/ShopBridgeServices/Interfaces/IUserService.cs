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
        Task<int> CreateUser(User User);
        Task<int> UpdateUser(User User);
        Task<int> DeleteUser(User User);
    }
}
