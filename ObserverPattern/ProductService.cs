using Newtonsoft.Json;
using ObserverPattern.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverPattern
{
    public class ProductService:IProductService
    {
       static private HttpClient _httpClient;
       private string _baseurl = "http://localhost:3000/";

        public ProductService(HttpClient httpClient) 
        {
            _httpClient = httpClient;


            _httpClient.BaseAddress = new Uri(Baseurl);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string Baseurl { get => _baseurl; set => _baseurl = value; }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {


            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("product/products/12");
                var Json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ProductApiErrorResponse>(Json);
                    Console.WriteLine($"Error {errorResponse?.Message}");
                    throw new HttpRequestException(errorResponse?.Message);
                }

                
                Console.WriteLine(Json);
                var result = JsonConvert.DeserializeObject<ProductApiResponse<IEnumerable<ProductDto>>>(Json);

                /*lanzar una exepcion si el codigo de estado de la solicitud esta fueta del rango: 200-209*/
                //response.EnsureSuccessStatusCode();

                var ProductList = result?.Data?.Select(dto => new Product
                {
                    Barcode = dto.BarCode,
                    Name = dto.Name,
                    SalePrice = dto.SalePrice,
                    PurchasePrice = dto.PurchasePrice,
                    UnitMeasure = dto.UnitMeasure,
                    MinStock = dto.MinStock ?? 0,
                    Stock = dto.Stock,
                    ProfitPercentage = dto.ProfitPercentage ?? 0m
                });

                return ProductList;
            }
            catch (HttpRequestException e)
            {

                MessageBox.Show(e.Message.ToString());
                return null;
            }
            

           
        }


        public async Task<Product> GetProductByBarCodeAsync(string bar_code)
        {
            Product p = null;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"product/barcode/{bar_code}");

                var Json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ProductApiErrorResponse>(Json);
                    Console.WriteLine($"Error {errorResponse?.Message}");
                    throw new HttpRequestException(errorResponse?.Message);
                }

                
                
                Console.WriteLine(Json);

                var result = JsonConvert.DeserializeObject<ProductApiResponse<ProductDto>>(Json);

                if (result?.Data == null) 
                {
                    
                    return null ;
                }
                
                var dto = result.Data;
                p = new Product { 
                    Name = dto.Name,
                    SalePrice = dto.SalePrice,
                    PurchasePrice= dto.PurchasePrice,
                    Barcode = dto.BarCode,
                    Stock = dto.Stock,
                    MinStock = dto.MinStock ?? 0,
                    UnitMeasure = dto.UnitMeasure,
                    ProfitPercentage = dto.ProfitPercentage ?? 0m,
                
                };

            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message);
                return null ;
            }
            
            return p;
        }
    }
}
