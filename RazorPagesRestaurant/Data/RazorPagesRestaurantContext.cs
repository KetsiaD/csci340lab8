using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesRestaurant.Models;

namespace RazorPagesRestaurant.Data
{
    public class RazorPagesRestaurantContext : DbContext
    {
        public RazorPagesRestaurantContext (DbContextOptions<RazorPagesRestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesRestaurant.Models.Restaurant> Restaurant { get; set; } = default!;
    }
}
