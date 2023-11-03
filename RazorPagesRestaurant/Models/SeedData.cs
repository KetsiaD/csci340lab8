using Microsoft.EntityFrameworkCore;
using RazorPagesRestaurant.Data;

namespace RazorPagesRestaurant.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesRestaurantContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesRestaurantContext>>()))
        {
            if (context == null || context.Restaurant == null)
            {
                throw new ArgumentNullException("Null RazorPagesRestaurantContext");
            }

            // Look for any movies.
            if (context.Restaurant.Any())
            {
                return;   // DB has been seeded
            }

            context.Restaurant.AddRange(
                new Restaurant
                {
                    Name = "Brick&Forge",
                    Location = "Conway",
                    Price = 40,
                    Order = "Alfredo Pasta"
                },

                new Restaurant
                {
                    Name = "JJ",
                    Location = "Conway",
                    Price = 50,
                    Order = "Mac&Cheese"
                },

                new Restaurant
                {
                    Name = "Mike's",
                    Location = "Conway",
                    Price = 50,
                    Order = "Alfedo Pasta"
                },

                new Restaurant
                {
                    Name = "Rooftop",
                    Location = "Littlerock",
                    Price = 50,
                    Order = "Grilled Chicken Specials"
                }
            );
            context.SaveChanges();
        }
    }
}