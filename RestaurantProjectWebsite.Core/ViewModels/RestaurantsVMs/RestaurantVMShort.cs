using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs
{
    public class RestaurantVMShort
    {
        [Required]
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

    }
}
