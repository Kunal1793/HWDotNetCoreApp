using HWRestaurant.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWRestaurant.Data
{
    public class RestaurantDbContext : DbContext
    
    // Used to Connect to a Database.
    // POCO Class --> Representatin of Tbales.
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> restaurants { get; set; }
    }
}
