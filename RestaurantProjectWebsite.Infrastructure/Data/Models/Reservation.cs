using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Reservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        public ICollection<Ocasions>? Ocasions { get; set; }
        public string? SpecalRequirements { get; set; }  

    }
}
//-Id Guid
//- DateTime date
//- NumberOfPeople int
//-Occasion? string
//-Special Requirements? string