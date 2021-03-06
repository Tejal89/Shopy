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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShopBridgeContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindByCondition(x => x.IsDeleted == false)
               .OrderByDescending(x=> x.ProductId)
               .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(long ProductId)
        {
            return await FindByCondition(x => x.ProductId.Equals(ProductId) &&  x.IsDeleted == false)
                .FirstOrDefaultAsync();
        }
        
        public async Task<int> CreateProduct(Product Product)
        {
            return await Create(Product);
        }

        public async Task<int> UpdateProduct(Product Product)
        {
            return await Update(Product);
        }

        public async Task<int> DeleteProduct(Product Product)
        {
            return await Delete(Product);
        }
    }
}
