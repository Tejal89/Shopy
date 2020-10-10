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
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _IInventoryRepository;
        
        public InventoryService(IInventoryRepository IInventoryRepository)
        {
            _IInventoryRepository = IInventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _IInventoryRepository.GetAllInventoriesAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(long InventoryId)
        {
            return await _IInventoryRepository.GetInventoryByIdAsync(InventoryId);
        }

        public async Task<Inventory> GetInventoryByProductIdAsync(long ProductId)
        {
            return await _IInventoryRepository.GetInventoryByProductIdAsync(ProductId);
        }

        public async Task<int> CreateInventory(Inventory Inventory)
        {
            return await _IInventoryRepository.CreateInventory(Inventory);
        }
        
        public async Task<int> UpdateInventory(Inventory Inventory)
        {
            return await _IInventoryRepository.UpdateInventory(Inventory);
        }
        
        public async Task<int> DeleteInventory(Inventory Inventory)
        {
            return await _IInventoryRepository.DeleteInventory(Inventory);
        }
    }
}
