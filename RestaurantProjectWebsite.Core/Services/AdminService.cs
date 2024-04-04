using RestauranProjectWebsite.Infrastructure.Repositories;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;
using RestaurantProjectWebsite.Core.ViewModels.ReviewVMs;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IApplicationDbRepository repo;

        public AdminService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> ApproveRestaurant(string restaurantId)
        {
            var restaurant = await repo.GetByIdAsync<Restaurant>(restaurantId);
            if (restaurant == null)
            {
                throw new ArgumentException("There was no restaurant with this Id");
            }

            restaurant.Request = false;
            await repo.SaveChangesAsync();
            return true;
        }

        public  List<ReviewVM> ReportedReview()
        {
            var reviews = repo.All<Review>().Where(r => r.Reported == true);
            var revieVMs = new List<ReviewVM>();
            if (reviews == null)
            {
                throw new Exception("There are no reviews reported");
            }
            foreach (var review in reviews)
            {

                ReviewVM reviewVM = new ReviewVM()
                {
                    Id = review.Id.ToString(),
                    Message = review.Message,
                    Reported = false,
                    RestaurantId = review.RestaurantId.ToString(),
                    UserId = review.UserId,
                    Score = review.Score,
                };
                revieVMs.Add(reviewVM);
            }

            return revieVMs;
        }
    }
}
