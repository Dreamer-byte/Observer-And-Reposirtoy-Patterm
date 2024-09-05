using Microsoft.Extensions.DependencyInjection;
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
        static async Task Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient<IProductService,ProductService>();
            serviceCollection.AddScoped<IRepositoryProduct, RepositoryProduct>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            var prodcutRepository = provider.GetRequiredService<IRepositoryProduct>();


            var ListProducts = await prodcutRepository.GetAllProductsAsync();


            if (ListProducts != null)
            {
                foreach (var product in ListProducts)
                {
                    Console.WriteLine(product.ToString());
                }
            }
            else 
            {
                Console.WriteLine("No se encontraron registros");
            
            }
            Console.WriteLine();
            Console.WriteLine("Buscar por el codigo de barras: ");
            string bar_code = Console.ReadLine();

            Product p = await prodcutRepository.GetProductByBarCodeAsync(bar_code);


            Console.ReadLine();
        }
    }
}
