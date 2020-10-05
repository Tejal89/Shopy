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
        void CreateInventory(Inventory Inventory);
        void UpdateInventory(Inventory Inventory);
        void DeleteInventory(Inventory Inventory);
    }
}
