using Microsoft.EntityFrameworkCore;
using CodeFirstLibraryMVC.Models;

namespace CodeFirstLibraryMVC.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Book>()
            .Property(b => b.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<Book>().HasData(
            new Book 
            { 
                Id = 1, 
                Title = "The Great Gatsby", 
                Author = "F. Scott Fitzgerald", 
                Genre = "Fiction", 
                TotalCopies = 5, 
                AvailableCopies = 5, 
                Price = 12.99m,
                CreatedDate = new DateTime(2024, 1, 1)  
            },
            new Book 
            { 
                Id = 2, 
                Title = "1984", 
                Author = "George Orwell", 
                Genre = "Dystopian", 
                TotalCopies = 3, 
                AvailableCopies = 3, 
                Price = 9.99m,
                CreatedDate = new DateTime(2024, 1, 1)  
            },
            new Book 
            { 
                Id = 3, 
                Title = "To Kill a Mockingbird", 
                Author = "Harper Lee", 
                Genre = "Fiction", 
                TotalCopies = 4, 
                AvailableCopies = 4, 
                Price = 14.99m,
                CreatedDate = new DateTime(2024, 1, 1) 
            }
        );
    }
}
