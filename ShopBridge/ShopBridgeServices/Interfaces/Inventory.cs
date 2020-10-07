using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeServices.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(long InventoryId);
        Task<bool> CreateInventory(Inventory Inventory);
        Task<bool> UpdateInventory(Inventory Inventory);
        Task<bool> DeleteInventory(Inventory Inventory);
    }
}
