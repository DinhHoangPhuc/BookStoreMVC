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
        public DbSet<Product> Products { get; set; }

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

            // Seed data for Products with real data and price in VND, all property must has value, create 10 records
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "C# Basics",
                    Description = "Introduction to C# programming",
                    ISBN = "978-1234567890",
                    Author = "John Doe",
                    ListPrice = 150000,
                    Price50 = 140000,
                    Price100 = 130000,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Advanced C#",
                    Description = "Deep dive into advanced C# concepts",
                    ISBN = "978-1234567891",
                    Author = "Jane Smith",
                    ListPrice = 250000,
                    Price50 = 230000,
                    Price100 = 220000,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "ASP.NET Core",
                    Description = "Learn modern web development with ASP.NET Core",
                    ISBN = "978-1234567892",
                    Author = "Steve Rogers",
                    ListPrice = 300000,
                    Price50 = 280000,
                    Price100 = 260000,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Entity Framework",
                    Description = "Master database interaction with Entity Framework",
                    ISBN = "978-1234567893",
                    Author = "Bruce Banner",
                    ListPrice = 200000,
                    Price50 = 180000,
                    Price100 = 170000,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "LINQ Essentials",
                    Description = "Learn LINQ with practical examples",
                    ISBN = "978-1234567894",
                    Author = "Natasha Romanoff",
                    ListPrice = 120000,
                    Price50 = 110000,
                    Price100 = 100000,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Design Patterns",
                    Description = "Explore common design patterns in software development",
                    ISBN = "978-1234567895",
                    Author = "Tony Stark",
                    ListPrice = 400000,
                    Price50 = 380000,
                    Price100 = 360000,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 7,
                    Title = "Clean Code",
                    Description = "Write better code with clean coding principles",
                    ISBN = "978-1234567896",
                    Author = "Robert Martin",
                    ListPrice = 350000,
                    Price50 = 330000,
                    Price100 = 300000,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 8,
                    Title = "Refactoring",
                    Description = "Learn techniques to improve existing code",
                    ISBN = "978-1234567897",
                    Author = "Martin Fowler",
                    ListPrice = 300000,
                    Price50 = 280000,
                    Price100 = 260000,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 9,
                    Title = "Agile Development",
                    Description = "Understand agile practices in software development",
                    ISBN = "978-1234567898",
                    Author = "Mike Cohn",
                    ListPrice = 220000,
                    Price50 = 200000,
                    Price100 = 180000,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 10,
                    Title = "DevOps Handbook",
                    Description = "Guide to implementing DevOps culture",
                    ISBN = "978-1234567899",
                    Author = "Gene Kim",
                    ListPrice = 500000,
                    Price50 = 480000,
                    Price100 = 450000,
                    CategoryId = 1,
                    ImageUrl = ""
                }
            );


        }
    }
}
