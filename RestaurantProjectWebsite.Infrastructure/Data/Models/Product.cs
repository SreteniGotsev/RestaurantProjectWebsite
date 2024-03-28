using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Infrastructure.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ProductType ProductType { get; set; }
        public SubProductType SubProductType { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public ICollection<Allergies>? Allergies { get; set; }
        public decimal Price { get; set; }

        

    }
}

//Product
//- Id Guid
//- Type(food / drink) string
// -SubType(starter/main/dessert/side) string
// -Restaurant sttring FK
// -Name string
// -Content string
// -Allergies array?
// -Price float