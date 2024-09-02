using System.Collections.Generic;

namespace ObserverPattern
{
    public class SubjetcProduct : ISubject
    {

        private List<IObserver> _observers;
        private Dictionary<int, int> _stockproducts;

        private IRepositoryProduct _repositoryProduct;
        private const int MIN_STOCK = 5;

        public SubjetcProduct(IRepositoryProduct repository)
        {
            _observers = new List<IObserver>();
            _stockproducts = new Dictionary<int, int>();
            _repositoryProduct = repository;

        }


        public void addObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void notificationObservers(int productId, int currentStock)
        {
            foreach (var observer in _observers) 
            {
                observer.Update(productId, currentStock);
            }

            
        }

        public void removeObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void updateStock(int productId, int newStock)
        {
            _stockproducts[productId] = newStock;

            var product = _repositoryProduct.GetProduct(productId);
            if (product != null)
            {
                product.Stock = newStock;
                _repositoryProduct.UpdateProduct(product);

                if (newStock < MIN_STOCK)
                {
                    notificationObservers(productId, newStock);

                }
            }

        }
    }
}
