using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    internal interface ISubject
    {
        void addObserver(IObserver observer);
        void removeObserver(IObserver observer);
        void notificationObservers(int productId, int currentStock);


    }
}
