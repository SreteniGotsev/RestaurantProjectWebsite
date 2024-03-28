using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<Product>? Products { get; set; }
        public Restaurant? Restaurant { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}

 //-Id Guid
 //-Number string
 //-List<Products> 
 //-Restaurant string FK
 //-User string FK
 //-PaymentType string
