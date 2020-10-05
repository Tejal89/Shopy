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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShopBridgeContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindAll()
               .OrderByDescending(x=> x.ProductId)
               .ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(long ProductId)
        {
            return await FindByCondition(x => x.ProductId.Equals(ProductId))
                .FirstOrDefaultAsync();
        }
        
        public void CreateProduct(Product Product)
        {
            Create(Product);
        }
        public void UpdateProduct(Product Product)
        {
            Update(Product);
        }
        public void DeleteProduct(Product Product)
        {
            Delete(Product);
        }
    }
}
