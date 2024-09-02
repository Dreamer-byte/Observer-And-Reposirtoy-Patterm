using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private List<Product> _products = new List<Product>();

        public List<Product> Products { get => _products; set => _products = value; }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void DeleteProduct(int id)
        {
            var product = GetProduct(id);
            
            if(product != null) 
            {
                Products.Remove(product);
            }

        }

        public IEnumerable<Product> GetAllProducts() => Products;

        public Product GetProduct(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public Product UpdateProduct(Product product)
        {
            var producttoUpated = GetProduct(product.Id);

            if (producttoUpated != null) 
            {
                producttoUpated.Name = product.Name;
                producttoUpated.Price = product.Price;
                producttoUpated.Stock  = product.Stock;
            }

            return producttoUpated;
        }
    }
    
}
