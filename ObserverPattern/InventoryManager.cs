using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class InventoryManager:IObserver
    {
        public void Update(int productId, int currentStock) 
        {
            Console.WriteLine($"Alerta: El producto con id: {productId}  tiene un stock bajo: {currentStock} unidades");
        }
    }
}
