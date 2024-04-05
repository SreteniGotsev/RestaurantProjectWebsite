using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;

namespace RestaurantProjectWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRestaurantService _restaurantService;

        public HomeController(IHttpContextAccessor contextAccessor, IRestaurantService restaurantService)
        {
            _contextAccessor = contextAccessor;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        //[ProducesResponseType(200,Type = typeof(RestaurantVMShort))]
        //[ProducesResponseType(404)]
        public IEnumerable<RestaurantVMShort> GetRestaurants()
        {
            return _restaurantService.GetAll();
            //return Ok(restaurants);
        }


    }

}
