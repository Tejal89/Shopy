using Microsoft.EntityFrameworkCore;
using ShopBridgeData.DataContext;
using ShopBridgeData.Entity;
using ShopBridgeRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Implementation
{
    public class InventoryLogRepository : RepositoryBase<InventoryLog>, IInventoryLogRepository
    {
        public InventoryLogRepository(ShopBridgeContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<InventoryLog>> GetAllInventoryLogsAsync()
        {
            return await FindAll()
               .OrderByDescending(x=> x.InventoryLogId)
               .ToListAsync();
        }
        public async Task<InventoryLog> GetInventoryLogByIdAsync(long InventoryLogId)
        {
            return await FindByCondition(x => x.InventoryLogId.Equals(InventoryLogId))
                .FirstOrDefaultAsync();
        }
        
        public async Task<int> CreateInventoryLog(InventoryLog InventoryLog)
        {
            return await Create(InventoryLog);
        }

        public async Task<int> UpdateInventoryLog(InventoryLog InventoryLog)
        {
            return await Update(InventoryLog);
        }

        public async Task<int> DeleteInventoryLog(InventoryLog InventoryLog)
        {
            return await Delete(InventoryLog);
        }
    }
}
