using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Catergory> Catergories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catergory>().HasData(
                new Catergory
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1
                },
                new Catergory
                {
                    Id = 2,
                    Name = "Science Fiction",
                    DisplayOrder = 2
                },
                new Catergory
                {
                    Id = 3,
                    Name = "Romance",
                    DisplayOrder = 3
                }
            );
        }
    }
}
