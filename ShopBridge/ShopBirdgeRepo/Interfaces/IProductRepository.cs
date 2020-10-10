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
        Task<int> CreateProduct(Product Product);
        Task<int> UpdateProduct(Product Product);
        Task<int> DeleteProduct(Product Product);
    }
}
