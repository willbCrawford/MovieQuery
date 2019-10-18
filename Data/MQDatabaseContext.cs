using Microsoft.EntityFrameworkCore;
using MovieQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Data
{
    public class MQDatabaseContext : DbContext
    {

        public MQDatabaseContext(DbContextOptions<MQDatabaseContext> options)
        : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<MovieCredit> MovieCredits { get; set; }
        public DbSet<MoviePlatform> MoviePlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviePlatform>()
                .HasKey(mp => new { mp.MovieId, mp.PlatformId });
            modelBuilder.Entity<MoviePlatform>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.MoviePlatforms)
                .HasForeignKey(mp => mp.MovieId);
            modelBuilder.Entity<MoviePlatform>()
                .HasOne(mp => mp.Platform)
                .WithMany(p => p.MoviePlatforms)
                .HasForeignKey(mp => mp.PlatformId);

            modelBuilder.Entity<MovieCredit>()
                .HasKey(mc => new { mc.MovieId, mc.CreditId });
            modelBuilder.Entity<MovieCredit>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCredits)
                .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCredit>()
                .HasOne(mc => mc.Credit)
                .WithMany(c => c.MovieCredits)
                .HasForeignKey(mc => mc.CreditId);
        }

        public DbSet<MovieQuery.Models.MovieCredit> MovieCredit { get; set; }
        public DbSet<MovieQuery.Models.MoviePlatform> MoviePlatform { get; set; }
    }
}
