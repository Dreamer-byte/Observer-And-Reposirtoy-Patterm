using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Product
    {
        
        private string name;
        private int stock;
        private int? min_stock;
        private decimal sale_price;
        private decimal purchase_price;
        private string bar_code;
        private string unit_measure;
        private decimal profit_percentage;

        public Product(string bar_code, string name, int stock, decimal sale_price, int min_stock, decimal purchase_price, string unit_measure, decimal profit_percentage)
        {
            Barcode = bar_code;
            Name = name;
            Stock = stock;
            SalePrice = sale_price;
            MinStock = min_stock;
            PurchasePrice = purchase_price;
            UnitMeasure = unit_measure;
            ProfitPercentage = profit_percentage;
        }

        public Product() { }


        #region Properties
        public string Barcode { get => bar_code; set => bar_code = value; }
        public string Name { get => name; set => name = value; }
        public int Stock { get => stock; set => stock = value; }
        public decimal SalePrice { get => sale_price; set => sale_price = value; }
        public string UnitMeasure { get => unit_measure; set => unit_measure = value; }
        public int? MinStock {
            get => min_stock;
            set 
            {
                if (value == null)
                    min_stock = 0;
                else
                    min_stock = value; 
            }
        }
        public decimal PurchasePrice { get => purchase_price; set => purchase_price = value; }
        public decimal ProfitPercentage { get => profit_percentage; set => profit_percentage = value; }
        #endregion



        public override string ToString() 
        {
            return $"Producto:\n Id: {this.Barcode}\n Nombre: {this.Name}\n Precio: {this.SalePrice}\n Stock: {this.Stock}\n";
        }
    }


    public class ProductDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string BarCode { get; set; }
        public string UnitMeasure { get; set; }
        public int? MinStock { get; set; }  // Permitir valores nulos
        public int Stock { get; set; }
        public decimal? ProfitPercentage { get; set; }  // Permitir valores nulos
       
    }
}
