using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeServices.Interfaces
{
    public interface IInventoryLogService
    {
        Task<IEnumerable<InventoryLog>> GetAllInventoryLogsAsync();
        Task<InventoryLog> GetInventoryLogByIdAsync(long InventoryLogId);
        Task<InventoryLog> CreateInventoryLog(InventoryLog InventoryLog);
        Task<InventoryLog> UpdateInventoryLog(InventoryLog InventoryLog);
        void DeleteInventoryLog(InventoryLog InventoryLog);
    }
}
