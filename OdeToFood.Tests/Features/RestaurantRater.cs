using OdeToFood.Models;
using OdeToFood.Tests.Features;
using System.Linq;

namespace OdeToFood.Tests.Controllers
{
    internal class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }
        
        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfReviewsToUse)
        {
            var filteredReviews = _restaurant.Reviews.Take(numberOfReviewsToUse);

            return algorithm.Compute(filteredReviews.ToList());
        }
    }
}