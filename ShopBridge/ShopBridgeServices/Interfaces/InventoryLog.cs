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
        Task<bool> CreateInventoryLog(InventoryLog InventoryLog);
        Task<bool> UpdateInventoryLog(InventoryLog InventoryLog);
        Task<bool> DeleteInventoryLog(InventoryLog InventoryLog);
    }
}
