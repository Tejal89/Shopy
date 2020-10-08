﻿using ShopBridgeData.Entity;
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
        Task<InventoryLog> CreateInventoryLog(InventoryLog InventoryLog);
        Task<InventoryLog> UpdateInventoryLog(InventoryLog InventoryLog);
        void DeleteInventoryLog(InventoryLog InventoryLog);
    }
}