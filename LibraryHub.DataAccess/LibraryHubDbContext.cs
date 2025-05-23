using LibraryHub.DataAccess.Data;
using LibraryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryHub.DataAccess;

public class LibraryHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public LibraryHubDbContext(DbContextOptions<LibraryHubDbContext> options)
        : base(options)
    {            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Seed.SeedData(modelBuilder);

        // Configure User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Email).IsRequired();
        });

        // Configure Book
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.ISBN).IsRequired();
            entity.HasOne(e => e.Author)
                  .WithMany(a => a.Books)
                  .HasForeignKey(e => e.AuthorId);
        });

        // Configure Author
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        // Configure Loan
        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithMany(u => u.Loans)
                  .HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Book)
                  .WithMany(b => b.Loans)
                  .HasForeignKey(e => e.BookId);
            entity.Property(e => e.LoanDate).IsRequired();
            entity.Property(e => e.DueDate).IsRequired();
        });

        // Configure Review
        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithMany(u => u.Reviews)
                  .HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Book)
                  .WithMany(b => b.Reviews)
                  .HasForeignKey(e => e.BookId);
            entity.Property(e => e.Rating).IsRequired();
            entity.Property(e => e.ReviewDate).IsRequired();
        });
    }
}
