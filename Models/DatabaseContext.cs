using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecordLabel.Models
{
    public partial class DatabaseContext : DbContext
    {

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        // Add Database tables here
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#error Make sure to update the connection strin gto the correct database
                optionsBuilder.UseNpgsql("server=localhost;database=RecordLabelDatabase");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongGenre>().HasKey(sg => new { sg.SongId, sg.GenreId });
        }
    }
}
