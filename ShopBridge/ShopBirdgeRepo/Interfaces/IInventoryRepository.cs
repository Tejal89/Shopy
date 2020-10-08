using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Interfaces
{
    public interface IInventoryRepository : IRepositoryBase<Inventory>
    {
        Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(long InventoryId);
        Task<Inventory> GetInventoryByProductIdAsync(long ProductId);
        Task<Inventory> CreateInventory(Inventory Inventory);

        Task<Inventory> UpdateInventory(Inventory Inventory);
        void DeleteInventory(Inventory Inventory);
    }
}
