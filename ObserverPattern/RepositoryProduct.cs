using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly ProductService _productService;



        public RepositoryProduct(IProductService productservice) 
        {
            _productService = (ProductService)productservice;
        }

        

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productService.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByBarCodeAsync(string bar_code)
        {
           return await _productService.GetProductByBarCodeAsync(bar_code);
        }



        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
    
}
