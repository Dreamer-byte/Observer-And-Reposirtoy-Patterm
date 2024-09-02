using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new RepositoryProduct();

            var prodcut1 = new Product(1, "Laptop", 10, 1500.00m);
            var product2 = new Product(id:2,name:"Mouse",stock:8,price:25.00m);

            var product3 = new Product(id: 3, name: "Teclado", stock: 6, price: 45.00m);

            repository.AddProduct(prodcut1);
            repository.AddProduct(product2);
            repository.AddProduct(product3);

            var sujetoPropducto = new SubjetcProduct(repository);
            var gerente = new InventoryManager();

            sujetoPropducto.addObserver(gerente);

            sujetoPropducto.updateStock(1, 3);
            Thread.Sleep(5000);
            sujetoPropducto.updateStock(2, 4);



            Thread.Sleep(5000);
            Console.WriteLine(repository.GetProduct(1).ToString());
            Console.WriteLine(repository.GetProduct(2).ToString());



            Console.ReadLine();
        }
    }
}
