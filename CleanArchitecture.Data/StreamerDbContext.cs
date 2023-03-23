using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=localhost\SQLEXPRESS; Initial Catalog=Streamer; Integrated Security=True; TrustServerCertificate=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        //Esto se utiliza en casos por ej: Foreign key no se llama cómo la tabla referenciada, etc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(x => x.Actores)
                .WithMany(x => x.Videos)
                .UsingEntity<VideoActor>(
                    a => a.HasKey(e => new { e.ActorId, e.VideoId })
                );

        }

        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Director> Directores { get; set; }
    }
}
