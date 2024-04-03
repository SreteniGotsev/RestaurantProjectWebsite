using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Restaurant
    {
        public Restaurant() {
        
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Capacity { get; set; }
        public RestaurantCategory Category { get; set; }
        public bool Request {  get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public ApplicationUser User { get; set; }
        public ICollection<Product> Menu { get; set; } = new List<Product>();
        public ICollection<Order> Order { get; set; } = new List<Order>();
        public ICollection<int> Tables { get; set; } = new List<int>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();


    }

 //        "-Id Guid
 //-Name string
 //-Address string
 //-Phone string
 //-Email string
 //-ICollection<Products> Menu
 //-ICollection<Orders> Orders
 //-ICollection<Int> Tables
 //-Capacity Int
 //-Category string
 //-Request bool
 //-Manager UserId FK"

    
}
