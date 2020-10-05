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
        
        public void CreateInventoryLog(InventoryLog InventoryLog)
        {
            _IInventoryLogRepository.CreateInventoryLog(InventoryLog);
        }
        public void UpdateInventoryLog(InventoryLog InventoryLog)
        {
            _IInventoryLogRepository.UpdateInventoryLog(InventoryLog);
        }
        public void DeleteInventoryLog(InventoryLog InventoryLog)
        {
            _IInventoryLogRepository.DeleteInventoryLog(InventoryLog);
        }
    }
}
