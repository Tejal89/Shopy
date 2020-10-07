using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Interfaces
{
    public interface IInventoryLogRepository : IRepositoryBase<InventoryLog>
    {
        Task<IEnumerable<InventoryLog>> GetAllInventoryLogsAsync();
        Task<InventoryLog> GetInventoryLogByIdAsync(long InventoryLogId);
        Task<bool> CreateInventoryLog(InventoryLog InventoryLog);
        Task<bool> UpdateInventoryLog(InventoryLog InventoryLog);
        Task<bool> DeleteInventoryLog(InventoryLog InventoryLog);
    }
}
