using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    internal class ProductApiResponse<T>
    {

        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
