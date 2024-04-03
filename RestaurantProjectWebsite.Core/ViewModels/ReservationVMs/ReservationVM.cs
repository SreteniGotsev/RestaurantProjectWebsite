using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.ViewModels.ReservationVMs
{
    public class ReservationVM
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        public List<string>? Ocasions { get; set; }
        public string? SpecalRequirements { get; set; }
    }
}
