using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public string? Message { get; set; }
        public double Score { get; set; }
        public bool Reported { get; set; }
    }
}

//-Title Guid
// - Message string
// -Score int
// -Reported bool
