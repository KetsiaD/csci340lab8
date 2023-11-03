using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesRestaurant.Data;
using RazorPagesRestaurant.Models;

namespace RazorPagesRestaurant.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesRestaurant.Data.RazorPagesRestaurantContext _context;

        public DetailsModel(RazorPagesRestaurant.Data.RazorPagesRestaurantContext context)
        {
            _context = context;
        }

      public Restaurant Restaurant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            else 
            {
                Restaurant = restaurant;
            }
            return Page();
        }
    }
}
