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
        Product GetProduct(int id);
        void DeleteProduct(int id);
        Product UpdateProduct(Product product);
        IEnumerable<Product> GetAllProducts();


    }
}
