using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridge.Middlewares;
using ShopBridgeData.Entity;
using ShopBridgeServices;
using ShopBridgeServices.Interfaces;
using io = System.IO;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public ProductController(ILogger<ProductController> logger, IWebHostEnvironment hostingEnvironment,
            IProductService productService, IInventoryService inventoryService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _productService = productService;
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Description : To get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            string path = io.Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "Uploads", "Products");
            var response = await _productService.GetAllProductsAsync();

            switch (response)
            {
                case null:
                    return Ok(new List<ProductInventory>());
                default:
                    var inventories = await _inventoryService.GetAllInventoriesAsync();
                    var inventory = new Inventory();
                    List<ProductInventory> inventoryList = new List<ProductInventory>();
                    if (response != null && response.Count() > 0)
                    {
                        foreach (Product product in response)
                        {
                            inventory = inventories.FirstOrDefault(x => x.ProductId == product.ProductId);
                            inventoryList.Add(new ProductInventory
                            {
                                ProductId = product.ProductId,
                                ProductName = product.ProductName,
                                ProductDescription = product.ProductDescription,
                                ProductImage = string.IsNullOrEmpty(product.ProductImage) ? string.Empty : io.Path.Combine(path, product.ProductImage),
                                IsActive = product.IsActive ?? false,
                                InventoryId = inventory == null ? 0: inventory.InventoryId,
                                InventoryQuantity = inventory == null ? 0 : inventory.InventoryQuantity
                            });

                        }
                    }

                    return Ok(inventoryList.ToList());
            }
        }

        /// <summary>
        /// Description : To get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] long id)
        {
            string path = io.Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "Uploads", "Products");
            var response = await _productService.GetProductByIdAsync(id);

            switch (response)
            {
                case null:
                    return StatusCode(500);
                default:

                    var inventory = await _inventoryService.GetInventoryByProductIdAsync(id);

                    return Ok(new ProductInventory()
                    {
                        ProductId = response.ProductId,
                        ProductName = response.ProductName,
                        ProductDescription = response.ProductDescription,
                        ProductImage = string.IsNullOrEmpty(response.ProductImage) ? string.Empty : io.Path.Combine(path, response.ProductImage),
                        IsActive = response.IsActive ?? false,
                        InventoryId = inventory == null ? 0 : inventory.InventoryId,
                        InventoryQuantity = inventory == null ? 0 : inventory.InventoryQuantity
                    });
            }
        }

        /// <summary>
        /// Description : To create a new product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([ModelBinder(BinderType = typeof(JsonModelBinder))] Prod product, IFormFile file)
        {
            if (product == null || product.ProductId != 0)
                return BadRequest();

            var products = await _productService.GetAllProductsAsync();
            if (products != null && products.ToList().Any(x => x.ProductId != product.ProductId && x.ProductName.ToLowerInvariant() == product.ProductName.ToLowerInvariant()))
            {
                return Conflict();
            }

            //reset image if file is null
            //product.ProductImage = file == null ? string.Empty : product.ProductImage;

            if (!string.IsNullOrEmpty(product.ProductImage))
            {
                string path = io.Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "Uploads", "Products");

                if (!io.Directory.Exists(path))
                {
                    io.Directory.CreateDirectory(path);
                }

                if (io.File.Exists(io.Path.Combine(path, product.ProductImage)))
                {
                    io.File.Delete(io.Path.Combine(path, product.ProductImage));
                }

                io.File.Create(io.Path.Combine(path, product.ProductImage));
            }

            product.IsActive = product.IsActive ?? false;
            product.IsDeleted = false;
            product.CreatedBy = 1;
            product.CreatedDate = DateTime.UtcNow;

            var response = await _productService.CreateProduct(product);

            switch (response)
            {
                case 0:
                    return StatusCode(500);
                default:

                    products = await _productService.GetAllProductsAsync();
                    product.ProductId = products.FirstOrDefault(x => x.ProductImage.ToLowerInvariant() == product.ProductImage.ToLowerInvariant()).ProductId;
                    Inventory inventory = new Inventory
                    {
                        InventoryQuantity = product.InventoryQuantity,
                        ProductId = product.ProductId,
                        CreatedBy = 1,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _inventoryService.CreateInventory(inventory);
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To update a product
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateUser([ModelBinder(BinderType = typeof(JsonModelBinder))] Prod product, IFormFile file)
        {
            if (product == null || product.ProductId <= 0)
                return BadRequest();

            var products = await _productService.GetAllProductsAsync();
            if (products != null && products.ToList().Any(x => x.ProductId != product.ProductId && x.ProductName.ToLowerInvariant() == product.ProductName.ToLowerInvariant()))
            {
                return Conflict();
            }

            if (products != null && !products.ToList().Any(x => x.ProductId == product.ProductId))
            {
                return NotFound();
            }

            //reset image if file is null
            //product.ProductImage = file == null ? string.Empty : product.ProductImage;

            //delete old file if exists
            string path = io.Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "Uploads", "Products");
            var oldImage = string.Empty;
            var oldProduct = products.FirstOrDefault(x => x.ProductId == product.ProductId);
            oldImage = oldProduct.ProductImage;

            if (!string.IsNullOrEmpty(oldImage))
            {
                if (io.File.Exists(io.Path.Combine(path, oldImage)))
                {
                    io.File.Delete(io.Path.Combine(path, oldImage));
                }
            }

            //upload new file
            if (!string.IsNullOrEmpty(product.ProductImage))
            {
                if (!io.Directory.Exists(path))
                {
                    io.Directory.CreateDirectory(path);
                }

                if (io.File.Exists(io.Path.Combine(path, product.ProductImage)))
                {
                    io.File.Delete(io.Path.Combine(path, product.ProductImage));
                }

                io.File.Create(io.Path.Combine(path, product.ProductImage));
            }

            product.IsActive = product.IsActive ?? false;
            product.IsDeleted = false;
            product.UpdatedBy = 1;
            product.UpdatedDate = DateTime.UtcNow;

            var response = await _productService.UpdateProduct(product);

            switch (response)
            {
                case 0:
                    return StatusCode(500);
                default:

                    var existingInventory = await _inventoryService.GetInventoryByProductIdAsync(product.ProductId);

                    if (existingInventory == null)
                    {
                        Inventory inventory = new Inventory
                        {
                            InventoryQuantity = product.InventoryQuantity,
                            ProductId = product.ProductId,
                            CreatedBy = 1,
                            CreatedDate = DateTime.UtcNow
                        };

                        await _inventoryService.CreateInventory(inventory);
                    }
                    else
                    {
                        existingInventory.InventoryQuantity = product.InventoryQuantity;
                        await _inventoryService.UpdateInventory(existingInventory);
                    }


                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            if (id <= 0)
                return BadRequest();

            var products = await _productService.GetAllProductsAsync();
            if (products != null && !products.ToList().Any(x => x.ProductId != id))
            {
                return BadRequest();
            }

            var product = products.ToList().FirstOrDefault(x => x.ProductId == id);
            product.IsDeleted = true;
            product.DeletedBy = 1;
            product.DeletedDate = DateTime.UtcNow;

            await _productService.UpdateProduct(product);

            return Ok();
        }
    }
}