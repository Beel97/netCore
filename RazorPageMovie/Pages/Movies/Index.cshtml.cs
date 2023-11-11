using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext1 _context;

        public IndexModel(RazorPageMovie.Data.RazorPageMovieContext1 context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres {  get; set; }
        [BindProperty(SupportsGet =true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string>genreQuery = from m in _context.Movie
                                           orderby m.Genere
                                           select m.Genere;

            var movies = from m in _context.Movie select m;
            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = Movie.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genere == MovieGenre);
            }
                                          
            if (_context.Movie != null)
            {
                Genres = new SelectList(await genreQuery.ToListAsync());
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
