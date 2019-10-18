using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieQuery.Data;
using System;
using System.Linq;

namespace MovieQuery.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MQDatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MQDatabaseContext>>());
            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG"
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG"
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Taxi Driver",
                    ReleaseDate = DateTime.Parse("1976-2-9"),
                    Genre = "Drama",
                    Rating = "R"
                }
            );

            context.Credits.AddRange(
                new Credit
                {
                    FirstName = "Rob",
                    LastName = "Reidner"
                },

                new Credit
                {
                    FirstName = "Nora",
                    LastName = "Ephnor"
                },

                new Credit
                {
                    FirstName = "Ivan",
                    LastName = "Reitman"
                },

                new Credit
                {
                    FirstName = "Dan",
                    LastName = "Aykroyd"
                },

                new Credit
                {
                    FirstName = "Harold",
                    LastName = "Ramis"
                },

                new Credit
                {
                    FirstName = "Howard",
                    LastName = "Hawks"
                },

                new Credit
                {
                    FirstName = "Jules",
                    LastName = "Furthman"
                },

                new Credit
                {
                    FirstName = "Martin",
                    LastName = "Scorcese"
                }
            );

            context.Platforms.AddRange(
                new Platform
                {
                    Title = "Netflix"
                },

                new Platform
                {
                    Title = "Hulu"
                },

                new Platform
                {
                    Title = "Amazon Prime"
                }
            );

            /*
            context.MovieCredit.AddRange(
                new MovieCredit
                {
                    MovieId = 5,
                    CreditId = 8
                }
            );
            */

            context.SaveChanges();
        }
    }
}
