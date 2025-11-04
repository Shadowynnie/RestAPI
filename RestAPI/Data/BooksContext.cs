using RestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    Author = "George Orwell",
                    PublishedDate = new DateOnly(1949, 6, 8),
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    PublishedDate = new DateOnly(1960, 7, 11),
                },
                new Book
                {
                    Id = 3,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    PublishedDate = new DateOnly(1925, 4, 10),
                },
                new Book
                {
                    Id = 4,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    PublishedDate = new DateOnly(1951, 7, 16),
                },
                new Book
                {
                    Id = 5,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Author = "J.K. Rowling",
                    PublishedDate = new DateOnly(1997, 6, 26),
                },
                new Book
                {
                    Id = 6,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    PublishedDate = new DateOnly(1937, 9, 21),
                },
                new Book
                {
                    Id = 7,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    PublishedDate = new DateOnly(1813, 1, 28),
                },
                new Book
                {
                    Id = 8,
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    PublishedDate = new DateOnly(2003, 3, 18),
                },
                new Book
                {
                    Id = 9,
                    Title = "The Road",
                    Author = "Cormac McCarthy",
                    PublishedDate = new DateOnly(2006, 9, 26),
                },
                new Book
                {
                    Id = 10,
                    Title = "The Girl with the Dragon Tattoo",
                    Author = "Stieg Larsson",
                    PublishedDate = new DateOnly(2005, 8, 1),
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDB;Trusted_Connection=True;");
        }
    }
}
