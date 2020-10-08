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

        public async Task<User> CreateUser(User User)
        {
            return await _IUserRepository.CreateUser(User);
        }

        public async Task<User> UpdateUser(User User)
        {
            return await _IUserRepository.UpdateUser(User);
        }

        public async void DeleteUser(User User)
        {
            _IUserRepository.DeleteUser(User);
        }
    }
}
