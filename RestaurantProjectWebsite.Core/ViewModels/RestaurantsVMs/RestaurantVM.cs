using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantProjectWebsite.Infrastructure.Data;
using RestaurantProjectWebsite.Infrastructure.Data.Models;

namespace RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs
{
    public class RestaurantVM
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Capacity { get; set; }
        public string Category { get; set; }
        public bool Request { get; set; }
        public string UserId { get; set; }
        public List<Product> Menu { get; set; } 
        public List<Order> Order { get; set; } 
        public List<int> Tables { get; set; } 
        public List<Reservation> Reservations { get; set; } 
        public List<Review> Reviews { get; set; } 
    }
}
