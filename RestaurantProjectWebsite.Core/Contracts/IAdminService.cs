using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;
using RestaurantProjectWebsite.Core.ViewModels.ReviewVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Contracts
{
    public interface IAdminService
    {
        Task<bool> ApproveRestaurant(string restaurantId);
        List<ReviewVM> ReportedReview();
    }
}

//-addRestaurantRequest(RestaurantViewModel)      M
//- reportReview                                   E, U, M