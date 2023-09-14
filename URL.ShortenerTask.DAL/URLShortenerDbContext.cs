using Microsoft.EntityFrameworkCore;
using URLShortenerTask.Domain.Entities;
using URLShortenerTask.Domain.Models;

namespace URLShortenerTask.DAL
{
    public class URLShortenerDbContext : DbContext
    {
        public DbSet<UrlEntity> Urls { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public URLShortenerDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UrlEntity>(option =>
            {
                option.Property(x => x.ShortUrl).HasMaxLength(7);
                option.HasIndex(e => e.ShortUrl).IsUnique();
            });
        }
    }
}
