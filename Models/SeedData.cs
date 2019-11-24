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
                },
                new Movie
                {
                    Title = "Superbad",
                    ReleaseDate = DateTime.Parse("2007-8-17"),
                    Genre = "Comedy",
                    Rating = "R"
                }
            );

            context.Credits.AddRange(
                new Credit
                {
                    CreditName = "Director",
                    FirstName = "Rob",
                    LastName = "Reidner"
                },

                new Credit
                {
                    CreditName = "Writer",
                    FirstName = "Nora",
                    LastName = "Ephnor"
                },

                new Credit
                {
                    CreditName = "Director",
                    FirstName = "Ivan",
                    LastName = "Reitman"
                },

                new Credit
                {
                    CreditName = "Writer",
                    FirstName = "Dan",
                    LastName = "Aykroyd"
                },

                new Credit
                {
                    CreditName = "Writer",
                    FirstName = "Harold",
                    LastName = "Ramis"
                },

                new Credit
                {
                    CreditName = "Director",
                    FirstName = "Howard",
                    LastName = "Hawks"
                },

                new Credit
                {
                    CreditName = "Writer",
                    FirstName = "Jules",
                    LastName = "Furthman"
                },

                new Credit
                {
                    CreditName = "Writer",
                    FirstName = "Martin",
                    LastName = "Scorcese"
                },

                new Credit
                {
                    CreditName = "Director",
                    FirstName = "Greg",
                    LastName = "Mottola"
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

            
            //context.MovieCredit.AddRange(
            //    new MovieCredit
            //    {
            //        MovieId = 1,
            //        CreditId = 1
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 1,
            //        CreditId = 2
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 2,
            //        CreditId = 3
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 2,
            //        CreditId = 4
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 2,
            //        CreditId = 5
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 3,
            //        CreditId = 3
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 3,
            //        CreditId = 4
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 3,
            //        CreditId = 5
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 4,
            //        CreditId = 6

            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 4,
            //        CreditId = 7,
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 5,
            //        CreditId = 8
            //    },

            //    new MovieCredit
            //    {
            //        MovieId = 6,
            //        CreditId = 9
            //    }
            //);

            //context.MoviePlatforms.AddRange(
            //    new MoviePlatform
            //    {
            //        MovieId = 5,
            //        PlatformId = 1
            //    },

            //    new MoviePlatform
            //    {
            //        MovieId = 6,
            //        PlatformId = 1
            //    }
            //);

            context.SaveChanges();
        }
    }
}
