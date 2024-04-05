using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProjectWebsite.Server.Controllers
{
    [Authorize(Roles = "Manager")]
    [Authorize(Roles = "User")]

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
    }
}
