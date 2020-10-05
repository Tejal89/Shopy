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
        
        public void CreateInventory(Inventory Inventory)
        {
            _IInventoryRepository.CreateInventory(Inventory);
        }
        public void UpdateInventory(Inventory Inventory)
        {
            _IInventoryRepository.UpdateInventory(Inventory);
        }
        public void DeleteInventory(Inventory Inventory)
        {
            _IInventoryRepository.DeleteInventory(Inventory);
        }
    }
}
