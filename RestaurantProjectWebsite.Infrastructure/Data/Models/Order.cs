using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<ProductsPerOrder>? Products { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? RestaurantId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

 //-Id Guid
 //-Number string
 //-List<Products> 
 //-Restaurant string FK
 //-User string FK
 //-PaymentType string
