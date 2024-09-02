using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Product
    {
        private int id;
        private string name;
        private int stock;
        private decimal price;
        private object value1;
        private object value2;

        public Product(object value1, object value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        public Product(int id, string name, int stock, decimal price)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Stock { get => stock; set => stock = value; }
        public decimal Price { get => price; set => price = value; }

        public override string ToString() 
        {
            return $"Producto:\n Id: {this.Id}\n Nombre: {this.Name}\n Precio: {this.Price}\n Stock: {this.Stock}\n";
        }
    }
}
