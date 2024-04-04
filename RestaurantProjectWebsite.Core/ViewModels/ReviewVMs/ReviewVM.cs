using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.ViewModels.ReviewVMs
{
    public class ReviewVM
    {
        public string Id { get; set; } 
        public string UserId { get; set; }
        public string RestaurantId { get; set; }
        public string? Message { get; set; }
        public double Score { get; set; }
        public bool Reported { get; set; }
    }
}
