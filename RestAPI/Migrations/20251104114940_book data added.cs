using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class bookdataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "George Orwell", new DateOnly(1949, 6, 8), "1984" },
                    { 2, "Harper Lee", new DateOnly(1960, 7, 11), "To Kill a Mockingbird" },
                    { 3, "F. Scott Fitzgerald", new DateOnly(1925, 4, 10), "The Great Gatsby" },
                    { 4, "J.D. Salinger", new DateOnly(1951, 7, 16), "The Catcher in the Rye" },
                    { 5, "J.K. Rowling", new DateOnly(1997, 6, 26), "Harry Potter and the Philosopher's Stone" },
                    { 6, "J.R.R. Tolkien", new DateOnly(1937, 9, 21), "The Hobbit" },
                    { 7, "Jane Austen", new DateOnly(1813, 1, 28), "Pride and Prejudice" },
                    { 8, "Dan Brown", new DateOnly(2003, 3, 18), "The Da Vinci Code" },
                    { 9, "Cormac McCarthy", new DateOnly(2006, 9, 26), "The Road" },
                    { 10, "Stieg Larsson", new DateOnly(2005, 8, 1), "The Girl with the Dragon Tattoo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
