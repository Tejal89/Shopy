﻿using Microsoft.EntityFrameworkCore;
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
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ShopBridgeContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await FindAll()
               .OrderByDescending(x=> x.InventoryId)
               .ToListAsync();
        }
        public async Task<Inventory> GetInventoryByIdAsync(long InventoryId)
        {
            return await FindByCondition(x => x.InventoryId.Equals(InventoryId))
                .FirstOrDefaultAsync();
        }
        
        public void CreateInventory(Inventory Inventory)
        {
            Create(Inventory);
        }
        public void UpdateInventory(Inventory Inventory)
        {
            Update(Inventory);
        }
        public void DeleteInventory(Inventory Inventory)
        {
            Delete(Inventory);
        }
    }
}
