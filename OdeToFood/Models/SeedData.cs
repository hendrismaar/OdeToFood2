using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Models
{
    public static class SeedData
    {
        public static void SeedRestaurant(ApplicationDbContext context)
        {
            if (!context.Restaurants.Any())
            {
                for (int i = 1; i <= 1000; i++)
                {
                    context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Sabatino's",
                        City = "Baltimore",
                        Country = "USA"
                    });
                    context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Great Lake",
                        City = "Chicago",
                        Country = "USA"
                    });
                    context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Smaka",
                        City = "Gothenburg",
                        Country = "Sweden",
                        //Reviews = new List<RestaurantReview>()
                        //{
                        //    new RestaurantReview()
                        //    {
                        //        Rating = 9,
                        //        Body = "Great food!"
                        //    }
                        //}
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}