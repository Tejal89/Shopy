using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopBridgeWeb.Helpers;
using ShopBridgeWeb.Pages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using io = System.IO;

namespace ShopBridgeWeb.Data
{
    public interface IProductService
    {
        Task<List<Prod>> GetAllProducts();
        Task<Prod> GetProductById(long id);
        Task<int> ManageProduct(Prod product,string file);
        Task<Prod> DeleteProduct(long id);
    }

    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        public static string _baseUrl,_getAllProducts, _getProductById, _createProduct, _updateProduct, _deleteProduct;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl =   configuration.GetSection("ApiConfig").GetValue("BaseUrl","");
            _getAllProducts = io.Path.Combine(_baseUrl, configuration.GetSection("ApiConfig").GetSection("Product").GetSection("GetAllProducts").Value);
            _getProductById =io.Path.Combine(_baseUrl,configuration.GetSection("ApiConfig").GetSection("Product").GetSection("GetProductById").Value);
            _createProduct = io.Path.Combine(_baseUrl,configuration.GetSection("ApiConfig").GetSection("Product").GetSection("CreateProduct").Value);
            _updateProduct = io.Path.Combine(_baseUrl,configuration.GetSection("ApiConfig").GetSection("Product").GetSection("UpdateProduct").Value);
            _deleteProduct = io.Path.Combine(_baseUrl, configuration.GetSection("ApiConfig").GetSection("Product").GetSection("DeleteProduct").Value);
        }
        public async Task<List<Prod>> GetAllProducts()
        {
            var _apiResponse = await ApiHelper.CallApi(_getAllProducts, HttpMethod.Get, null, "getAllProducts", null,null);

            if (_apiResponse != null && _apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Prod>>(_apiResponse.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        public async Task<Prod> GetProductById(long id)
        {
            var _apiResponse = await ApiHelper.CallApi(string.Format(_getProductById, id), HttpMethod.Get, null, "getProductById", null,null);

            if (_apiResponse != null && _apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Prod>(_apiResponse.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        /// <summary>
        /// Descrition : file upload pending
        /// </summary>
        /// <param name="product"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<int> ManageProduct(Prod product,string file)
        {
            //if (!String.IsNullOrEmpty(product.ProductImage) && file != null && file.Length > 0)
            //{
            //    product.ProductImage = product.ProductImage.Substring(product.ProductImage.ToString().LastIndexOf('\\')).Trim('\\');
            //}
            //else
            //{
            //    product.ProductImage = string.Empty;
            //    file = null;
            //}

            product.ProductImage = string.Empty;
            file = null;


            var json = JsonConvert.SerializeObject(product, Formatting.Indented).ToString();
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);

            dynamic _apiResponse;

            if (product.ProductId == 0)
            {
                _apiResponse = await ApiHelper.CallApi(_createProduct, HttpMethod.Put, bytes, "product", file == null ? null : Convert.FromBase64String(file),product.ProductImage);
            }
            else
            {
                _apiResponse = await ApiHelper.CallApi(_updateProduct, HttpMethod.Post, bytes, "product",file == null? null : Convert.FromBase64String(file), product.ProductImage);
            }

            if (_apiResponse != null && _apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return 1;
            }

            return 0;
        }

        public async Task<Prod> DeleteProduct(long id)
        {
            var _apiResponse = await ApiHelper.CallApi(string.Format(_deleteProduct, id), HttpMethod.Delete, null, "_deleteProduct", null,null);

            if (_apiResponse != null && _apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return new Prod();
            }

            return null;
        }
    }
}
