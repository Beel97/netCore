using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data; 

namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new RazorPageMovieContext1(serviceProvider.GetRequiredService<
                DbContextOptions<RazorPageMovieContext1>>()))
            {
                if(context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null razorpagecontext");
                }

                if(context.Movie.Any())
                {
                    //Base de datos muetra todo lo que contiene esta clase
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title="Ghostbusters",
                        RelaseDate=DateTime.Parse("1984-3-13"),
                        Genere="Comedy",
                        Price=8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        RelaseDate = DateTime.Parse("1989-2-23"),
                        Genere = "Comedy",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        RelaseDate = DateTime.Parse("1984-3-13"),
                        Genere = "Western",
                        Price = 3.99M
                    });
                    context.SaveChanges();

            }
        }
    }
}
