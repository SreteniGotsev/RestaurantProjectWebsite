using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebsite.Server.Controllers
{
    [Authorize(Roles = "User")]
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
    }
}
