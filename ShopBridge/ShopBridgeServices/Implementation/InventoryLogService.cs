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
    public class InventoryLogService : IInventoryLogService
    {
        private readonly IInventoryLogRepository _IInventoryLogRepository;
        
        public InventoryLogService(IInventoryLogRepository IInventoryLogRepository)
        {
            _IInventoryLogRepository = IInventoryLogRepository;
        }
        
        public async Task<IEnumerable<InventoryLog>> GetAllInventoryLogsAsync()
        {
            return await _IInventoryLogRepository.GetAllInventoryLogsAsync();
        }
        
        public async Task<InventoryLog> GetInventoryLogByIdAsync(long InventoryLogId)
        {
            return await _IInventoryLogRepository.GetInventoryLogByIdAsync(InventoryLogId);
        }
        
        public async Task<int> CreateInventoryLog(InventoryLog InventoryLog)
        {
            return await _IInventoryLogRepository.CreateInventoryLog(InventoryLog);
        }
        public async Task<int> UpdateInventoryLog(InventoryLog InventoryLog)
        {
            return await _IInventoryLogRepository.UpdateInventoryLog(InventoryLog);
        }
        public async Task<int> DeleteInventoryLog(InventoryLog InventoryLog)
        {
            return await _IInventoryLogRepository.DeleteInventoryLog(InventoryLog);
        }
    }
}
