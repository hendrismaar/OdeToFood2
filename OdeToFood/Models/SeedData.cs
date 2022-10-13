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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Restaurants.Any())
                {
                    return;   // DB has been seeded
                }

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