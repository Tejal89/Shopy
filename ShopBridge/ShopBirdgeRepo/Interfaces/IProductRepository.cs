using ShopBridgeData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(long ProductId);
        Task<Product> CreateProduct(Product Product);
        Task<Product> UpdateProduct(Product Product);
        void DeleteProduct(Product Product);
    }
}
