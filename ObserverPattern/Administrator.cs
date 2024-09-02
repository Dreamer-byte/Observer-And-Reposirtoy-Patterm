using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Administrator : IObserver
    {
        private string _name;

        public Administrator(string name)
        {
            _name = name;
        }

        public void Update(int productId, int currentStock)
        {
            Console.WriteLine($"Alerta; {this._name} el producto {productId} esta bajo de stock: {currentStock} unidades");
        }
    }
}
