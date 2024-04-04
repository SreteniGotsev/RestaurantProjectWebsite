using RestaurantProjectWebsite.Core.ViewModels.ProductVMs;
using RestaurantProjectWebsite.Infrastructure.Data;
using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.ViewModels.OrderVMs
{
    public class OrderVM
    {
        public string Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IDictionary<ProductVMShort,int>? Products { get; set; }
        public string RestaurantId { get; set; }
        public string UserId { get; set; }
        public string PaymentType { get; set; }
        public string TotalPrice { get; set; }
    }
}
