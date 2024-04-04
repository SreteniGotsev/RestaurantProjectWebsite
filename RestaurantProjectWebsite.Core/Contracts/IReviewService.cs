using RestaurantProjectWebsite.Core.ViewModels.ReviewVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Contracts
{
    public interface IReviewService
    {
        Task<ReviewVM> GetReview(string id);
        List<ReviewVM> GetAllReviewsByUser(string Id);
        List<ReviewVM> GetAllReviewsByRestaurant(string Id);
        Task<bool> AddReview(ReviewVM reviewVM);
        Task<bool> UpdateReview(ReviewVM reviewVM);
        Task<bool> RemoveReview(string Id);
    }
}

//-getAllReviewsBy(RestaurantId)                  E
//- getAllReviewsBy(UserId)                        U
//- addReview(ReviewVM, RestaurantId, UserId)      U
//- editReview(ReviewVM)                           U
//- deleteReview                                   U, A