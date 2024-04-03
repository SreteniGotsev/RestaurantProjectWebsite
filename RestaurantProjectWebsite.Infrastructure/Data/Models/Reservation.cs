using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        public ICollection<Ocasions>? Ocasions { get; set; }
        public string? SpecalRequirements { get; set; }

        [ForeignKey("User")] 
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
//-Id Guid
//- DateTime date
//- NumberOfPeople int
//-Occasion? string
//-Special Requirements? string