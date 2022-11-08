using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
	public static class SeedData
	{
		private const string ROLE_ADMIN = "Admin";
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{
				if (context.Restaurants.Any())
				{
					return;
				}
				context.Restaurants.AddRange(
					new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
					new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
					new Restaurant { Name = "Smaka", City = "Gothenburg", Country = "Sweden", Reviews = new List<RestaurantReview> { new RestaurantReview { Rating = 9, Body = "Great food!" } } });
                for (int i = 0; i < 1000 ; i++)
                {
					context.Restaurants.AddRange(
					new Restaurant { Name = $"{i}", City = "Nowhere", Country = "USA" });
                }
				
				context.SaveChanges();
			}
		}

		public static void SeedIdentity(UserManager<OdeToFoodUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var user =  userManager.FindByNameAsync("maarhendris@gmail.com").Result;
			
			if (user == null)
			{
				user = new OdeToFoodUser();
				user.Email = "maarhendris@gmail.com";
				user.EmailConfirmed = true;
				user.UserName = "maarhendris@gmail.com";
				IdentityResult result = userManager.CreateAsync(user).Result;
				if (result.Succeeded)
				{
					user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Maarhendris1!");
					var _ = userManager.UpdateAsync(user).Result;
				}
				else
				{
					throw new Exception($"User creation failed: {result.Errors.FirstOrDefault()}");
				}
			}
            var role = roleManager.FindByNameAsync("Admin").Result;
            if (role == null)
			{
				role = new IdentityRole(ROLE_ADMIN);
				IdentityResult result = roleManager.CreateAsync(role).Result;
				if (result.Succeeded)
				{
					userManager.AddToRoleAsync(user, ROLE_ADMIN);
				}
			}
		}
	}
}