using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Location { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RestaurantLocation { get; set; }



        public async Task OnGetAsync()
        {
    // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Restaurant
                                    orderby m.Location
                                    select m.Location;

            var movies = from m in _context.Restaurant
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(RestaurantLocation))
            {
                movies = movies.Where(x => x.Location == RestaurantLocation);
            }
            Location = new SelectList(await genreQuery.Distinct().ToListAsync());
            Restaurant = await movies.ToListAsync();
        }
    }
}
