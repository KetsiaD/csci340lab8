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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesRestaurant.Data.RazorPagesRestaurantContext _context;

        public IndexModel(RazorPagesRestaurant.Data.RazorPagesRestaurantContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Restaurant != null)
            {
                Restaurant = await _context.Restaurant.ToListAsync();
            }
        }
    }
}
