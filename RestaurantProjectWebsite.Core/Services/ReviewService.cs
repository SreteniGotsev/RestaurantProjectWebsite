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
using static System.Formats.Asn1.AsnWriter;

namespace RestaurantProjectWebsite.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IApplicationDbRepository repo;
        public ReviewService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> AddReview(ReviewVM reviewVM)
        {
            if (reviewVM == null)
            {
                throw new ArgumentNullException("The revieVM is empty!");
            }

            Review review = new Review()
            {
                Message = reviewVM.Message,
                Reported = false,
                RestaurantId = Guid.Parse(reviewVM.RestaurantId),
                UserId = reviewVM.UserId,
                Score = reviewVM.Score,
            };

            await repo.AddAsync(reviewVM);
            await repo.SaveChangesAsync();
            return true;
        }

        public List<ReviewVM> GetAllReviewsByRestaurant(string Id)
        {
            var reviews = repo.All<Review>().Where(r => r.RestaurantId == Guid.Parse(Id));
            var revieVMs = new List<ReviewVM>();
            if (reviews == null)
            {
                throw new Exception("There are no fucking reviews with this RestaurantId");
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

        public List<ReviewVM> GetAllReviewsByUser(string Id)
        {
            var reviews = repo.All<Review>().Where(r => r.UserId == Id);
            var reviewVMs = new List<ReviewVM>();
            if (reviews == null)
            {
                throw new Exception("There are no fucking reviews with this UserId");
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
                reviewVMs.Add(reviewVM);
            }

            return reviewVMs;
        }

        public async Task<ReviewVM> GetReview(string id)
        {
            var review = await repo.GetByIdAsync<Review>(id);

            if (review == null)
            {
                throw new Exception("There are is fucking reviews with this Id");
            }


            ReviewVM reviewVM = new ReviewVM()
            {
                Id = review.Id.ToString(),
                Message = review.Message,
                Reported = false,
                RestaurantId = review.RestaurantId.ToString(),
                UserId = review.UserId,
                Score = review.Score,
            };

            return reviewVM;
        }

        public async Task<bool> RemoveReview(string Id)
        {
            var review = await repo.GetByIdAsync<Review>(Id);
            if (review == null)
            {
                throw new ArgumentException("There was no reviw with that Id");
            }

            await repo.DeleteAsync<Review>(Id);
            await repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateReview(ReviewVM reviewVM)
        {
            var review = await repo.GetByIdAsync<Review>(reviewVM.Id);

            if (review == null)
            {
                throw new Exception("There are is fucking reviews with this Id");
            }

            review.Message = reviewVM.Message;
            review.Reported = false;
            review.RestaurantId = Guid.Parse(reviewVM.RestaurantId);
            review.UserId = reviewVM.UserId;
            review.Score = reviewVM.Score;

            await repo.SaveChangesAsync();
            return true;

        }

        public async Task<bool> ReportReview(string reviewId)
        {
            var review = await repo.GetByIdAsync<Review>(reviewId);
            if (review == null)
            {
                throw new ArgumentException("There was no review with that Id");
            }

            review.Reported = true;
            await repo.SaveChangesAsync();
            return true;
        }
    }
}
