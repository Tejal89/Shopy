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
        Task<int> CreateInventory(Inventory Inventory);

        Task<int> UpdateInventory(Inventory Inventory);
        Task<int> DeleteInventory(Inventory Inventory);
    }
}
