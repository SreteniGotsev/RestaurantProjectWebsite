using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Restaurant? Restaurant { get; set; }
        public string? Message { get; set; }
        public double Score { get; set; }
        public bool Reporte { get; set; }
    }
}

//-Title Guid
// - Message string
// -Score int
// -Reported bool
