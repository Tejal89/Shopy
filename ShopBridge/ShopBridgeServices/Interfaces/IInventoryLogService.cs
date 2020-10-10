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
        Task<int> CreateInventoryLog(InventoryLog InventoryLog);
        Task<int> UpdateInventoryLog(InventoryLog InventoryLog);
        Task<int> DeleteInventoryLog(InventoryLog InventoryLog);
    }
}
