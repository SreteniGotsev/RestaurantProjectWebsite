using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.ViewModels.ProductVMs
{
    public class ProductVMShort
    {
        public string Id { get; set; }
        public string ProductType { get; set; }
        public string SubProductType { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string RestaurantId { get; set; }
    }
}
