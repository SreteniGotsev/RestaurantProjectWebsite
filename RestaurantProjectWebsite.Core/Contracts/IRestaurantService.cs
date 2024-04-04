using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;
using RestaurantProjectWebsite.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Contracts
{
    public interface IRestaurantService
    {
        Task<RestaurantVM> GetRestauratById(string id);
        List<RestaurantVMShort> GetAll();
        List<RestaurantVMShort> GetAllByCategory(string category);
        Task<bool> AddRestaurant(RestaurantVM restaurantVm);
        Task<bool> UpdateRestaurant(RestaurantVM restaurant);
        Task<bool> RemoveRestaurant(string restaurantId);
    }
}

//-getRestaurant(id)                              E M-Manager
//-getAllRestaurants                              E                           U-User
//-getAllRestaurantsBy(Category)                  E                           E-Everyone
//-addRestaurant(RestaurantViewModel)             A
//-editRestaurant(RestaurantViewModel)            M
//-deleteRestaurantRequest(id) 