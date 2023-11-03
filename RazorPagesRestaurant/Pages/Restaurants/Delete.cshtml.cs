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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesRestaurant.Data.RazorPagesRestaurantContext _context;

        public DeleteModel(RazorPagesRestaurant.Data.RazorPagesRestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant.FindAsync(id);

            if (restaurant != null)
            {
                Restaurant = restaurant;
                _context.Restaurant.Remove(Restaurant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
