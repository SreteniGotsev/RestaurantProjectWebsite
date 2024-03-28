using Microsoft.AspNetCore.Identity;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Infrastructure.Data
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsManager { get; set; }
        public Restaurant? Restaurant { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Review> Reviews { get; set; }
    }
}
//-Id Guid
// - Name  string
// -Email string
// -Phone string
// -List<Orders> 
// -List<Reservations>
// -List<Reviews>
// -IsManager bool
// -Restaurant RestaurantId? FK
