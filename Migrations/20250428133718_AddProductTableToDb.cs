using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Catergories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", "Introduction to C# programming", "978-1234567890", 150000.0, 130000.0, 140000.0, "C# Basics" },
                    { 2, "Jane Smith", "Deep dive into advanced C# concepts", "978-1234567891", 250000.0, 220000.0, 230000.0, "Advanced C#" },
                    { 3, "Steve Rogers", "Learn modern web development with ASP.NET Core", "978-1234567892", 300000.0, 260000.0, 280000.0, "ASP.NET Core" },
                    { 4, "Bruce Banner", "Master database interaction with Entity Framework", "978-1234567893", 200000.0, 170000.0, 180000.0, "Entity Framework" },
                    { 5, "Natasha Romanoff", "Learn LINQ with practical examples", "978-1234567894", 120000.0, 100000.0, 110000.0, "LINQ Essentials" },
                    { 6, "Tony Stark", "Explore common design patterns in software development", "978-1234567895", 400000.0, 360000.0, 380000.0, "Design Patterns" },
                    { 7, "Robert Martin", "Write better code with clean coding principles", "978-1234567896", 350000.0, 300000.0, 330000.0, "Clean Code" },
                    { 8, "Martin Fowler", "Learn techniques to improve existing code", "978-1234567897", 300000.0, 260000.0, 280000.0, "Refactoring" },
                    { 9, "Mike Cohn", "Understand agile practices in software development", "978-1234567898", 220000.0, 180000.0, 200000.0, "Agile Development" },
                    { 10, "Gene Kim", "Guide to implementing DevOps culture", "978-1234567899", 500000.0, 450000.0, 480000.0, "DevOps Handbook" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Catergories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
