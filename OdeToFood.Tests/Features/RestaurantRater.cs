using OdeToFood.Models;

namespace OdeToFood.Tests.Controllers
{
    internal class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }
        
        public RatingResult ComputeRating(int numberOfReviews)
        {
            return new RatingResult() { Rating = 4 };
        }
    }
}