﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
