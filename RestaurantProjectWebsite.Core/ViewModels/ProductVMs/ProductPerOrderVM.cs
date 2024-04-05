using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.ViewModels.ProductVMs
{
    public class ProductPerOrderVM
    {
        public ProductVMShort Product {  get; set; }
        public string Quantity { get; set; }
    }
}
