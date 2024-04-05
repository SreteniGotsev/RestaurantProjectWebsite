using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;

namespace RestaurantProjectWebsite.Server.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public RestaurantController(IRestaurantService _restaurantService, IHttpContextAccessor _httpContextAccessor)
        {
            restaurantService = _restaurantService;
            httpContextAccessor = _httpContextAccessor;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(RestaurantVMShort))]
        [ProducesResponseType(404)]
        public async Task<RestaurantVM> GetRestaurantById(string Id)
        {
            return await restaurantService.GetRestauratById(Id);
            ;
        }
    }
}
