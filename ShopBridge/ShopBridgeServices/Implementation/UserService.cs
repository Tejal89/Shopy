using Microsoft.EntityFrameworkCore;
using ShopBridgeData.DataContext;
using ShopBridgeData.Entity;
using ShopBridgeRepo.Interfaces;
using ShopBridgeServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _IUserRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByIdAsync(long UserId)
        {
            return await _IUserRepository.GetUserByIdAsync(UserId);
        }
        
        public void CreateUser(User User)
        {
            _IUserRepository.CreateUser(User);
        }
        public void UpdateUser(User User)
        {
            _IUserRepository.UpdateUser(User);
        }
        public void DeleteUser(User User)
        {
            _IUserRepository.DeleteUser(User);
        }
    }
}
