using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IRepositoryProduct
    {
        void AddProduct(Product product);
        
        void DeleteProduct(int id);
        Product UpdateProduct(Product product);

        Task<Product> GetProductByBarCodeAsync(string bar_code);
        Task<IEnumerable<Product>> GetAllProductsAsync();


    }
}
