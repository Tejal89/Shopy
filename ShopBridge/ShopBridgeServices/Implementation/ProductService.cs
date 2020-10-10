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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _IProductRepository;
        
        public ProductService(IProductRepository IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _IProductRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(long ProductId)
        {
            return await _IProductRepository.GetProductByIdAsync(ProductId);
        }

        public async Task<int> CreateProduct(Product Product)
        {
            return await _IProductRepository.CreateProduct(Product);
        }

        public async Task<int> UpdateProduct(Product Product)
        {
            return await _IProductRepository.UpdateProduct(Product);
        }

        public async Task<int> DeleteProduct(Product Product)
        {
            return await _IProductRepository.DeleteProduct(Product);
        }
    }
}
