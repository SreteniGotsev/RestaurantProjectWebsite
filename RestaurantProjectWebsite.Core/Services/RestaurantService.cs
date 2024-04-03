using Microsoft.AspNetCore.Http;
using RestauranProjectWebsite.Infrastructure.Repositories;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;
using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IApplicationDbRepository repo;
        
        public RestaurantService(IApplicationDbRepository _repo)
        { 
            repo= _repo;
          
        }
        public async Task<bool> AddRestaurant(string RestaurantId)
        {
            var restaurant = await repo.GetByIdAsync<Restaurant>(RestaurantId);
            if (restaurant == null)
            {
                throw new ArgumentException("There was no restaurant with that Id");
            }
            restaurant.Request = false;
            await repo.SaveChangesAsync();
            return true;

        }

        public List<RestaurantVMShort> GetAll()
        {
            var restaurants = repo.All<Restaurant>().Where(r=>r.Request==false);
            List<RestaurantVMShort> restaurantsVMShorts = new List<RestaurantVMShort>();

            foreach (var restaurant in restaurants)
            {
                RestaurantVMShort restaurantVM = new RestaurantVMShort()
                {
                   Id = restaurant.Id.ToString(),
                   Name = restaurant.Name,
                   Address = restaurant.Address,
                   Phone = restaurant.Phone,
                };

                restaurantsVMShorts.Add(restaurantVM);
            }

            return restaurantsVMShorts;

        }

        public List<RestaurantVMShort> GetAllByCategory(string category)
        {
            var restaurants = repo.All<Restaurant>()
                .Where(r=>r.Category == (RestaurantCategory)Enum.Parse(typeof(RestaurantCategory),category) && r.Request == false);
            List<RestaurantVMShort> restaurantsVMShorts = new List<RestaurantVMShort>();

            foreach (var restaurant in restaurants)
            {
                RestaurantVMShort restaurantVM = new RestaurantVMShort()
                {
                    Id = restaurant.Id.ToString(),
                    Name = restaurant.Name,
                    Address = restaurant.Address,
                    Phone = restaurant.Phone,
                };

                restaurantsVMShorts.Add(restaurantVM);
            }

            return restaurantsVMShorts;
        }

        public async Task<RestaurantVM> GetRestauratById(string id)
        {
            var restaurant = await repo.GetByIdAsync<Restaurant>(id);

            RestaurantVM restaurantVM = new RestaurantVM()
            {
                Id = restaurant.Id.ToString(),
                Name = restaurant.Name,
                Address = restaurant.Address,
                Phone = restaurant.Phone,   
                Capacity = restaurant.Capacity,
                Category = restaurant.Category.ToString(),
                Email = restaurant.Email,
                Request = restaurant.Request, 
                UserId = restaurant.User.Id.ToString(),
                    
            };

            return restaurantVM;
        }

        public async Task<bool> RemoveRestaurant(string id)
        { 
            var restaurant = await repo.GetByIdAsync<Restaurant>(id);
            if (restaurant == null)
            {
                throw new ArgumentException("There was no restaurant with that Id");
            }
            await repo.DeleteAsync<Restaurant>(id);
            await repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRestaurant(RestaurantVM restaurantVM)
        {
            var restaurant = await repo.GetByIdAsync<Restaurant>(restaurantVM.Id);
            if (restaurant == null)
            {
                throw new ArgumentException("There was no restaurant with that Id");
            }

            restaurant.Name = restaurantVM.Name;
            restaurant.Address = restaurantVM.Address;
            restaurant.Phone = restaurantVM.Phone;
            restaurant.Capacity = restaurantVM.Capacity;
            restaurant.Category = (RestaurantCategory)Enum.Parse(typeof(RestaurantCategory),restaurantVM.Category);
           
            await repo.SaveChangesAsync();
            return true;
        }
    }
}
