using LibraryHub.Domain.Entities;
using LibraryHub.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibraryHub.DataAccess.Data;

public static class Seed
{
    // Define constant GUIDs in v4 format
    private const string User1Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479";
    private const string User2Id = "1b9d6bcd-bbfd-4b2d-9b5d-ab8dfbbd4bed";
    private const string User3Id = "68af4068-8e5a-4d7c-bc6e-9da9b0f41f9e";
    private const string User4Id = "2a35e6f1-4a6d-4e8f-8a9b-cdef01234567";
    private const string User5Id = "9c8b7a6d-5e4f-4a3b-2c1d-0e9f8a7b6c5d";

    private const string Author1Id = "a1b2c3d4-5678-4e8f-8a9b-cdef01234567";
    private const string Author2Id = "b2c3d4e5-6789-4f9a-8b0c-def012345678";
    private const string Author3Id = "c3d4e5f6-7890-4a1b-9c2d-ef0123456789";

    private const string Book1Id = "b1d2e3f4-5678-4a9b-8c0d-ef1234567890";
    private const string Book2Id = "2d3e4f56-7890-4b1c-9d2e-0f3456789abc";
    private const string Book3Id = "3e4f5678-90ab-4c2d-9e3f-10456789abc0";
    private const string Book4Id = "4f567890-abcd-4d3e-8f40-2156789abcde";
    private const string Book5Id = "567890ab-cdef-4e4f-9051-326789abcdef";
    private const string Book6Id = "67890abc-def0-4f50-9162-43789abcdef0";
    private const string Book7Id = "7890abc1-ef01-4061-9273-5489abcdef01";
    private const string Book8Id = "890abc23-f012-4172-9384-659abcdef012";
    private const string Book9Id = "90abc345-0123-4283-9495-76abcdef0123";
    private const string Book10Id = "0abc4567-1234-4394-9506-87bcdef01234";

    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.Parse(User1Id), Name = "Homer Simpson", Email = "homer@simpson.com" },
            new User { Id = Guid.Parse(User2Id), Name = "Peter Griffin", Email = "peter@griffin.com" },
            new User { Id = Guid.Parse(User3Id), Name = "Rick Sanchez", Email = "rick@sanchez.com" },
            new User { Id = Guid.Parse(User4Id), Name = "Leslie Knope", Email = "leslie@knope.com" },
            new User { Id = Guid.Parse(User5Id), Name = "Michael Scott", Email = "michael@scott.com" }
        );

        modelBuilder.Entity<Author>().HasData(
            new Author { Id = Guid.Parse(Author1Id), Name = "J.K. Rowling" },
            new Author { Id = Guid.Parse(Author2Id), Name = "George R.R. Martin" },
            new Author { Id = Guid.Parse(Author3Id), Name = "Stephen King" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = Guid.Parse(Book1Id), Title = "Harry Potter and the Philosopher's Stone", ISBN = "9780747532743", AuthorId = Guid.Parse(Author1Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book2Id), Title = "A Game of Thrones", ISBN = "9780553103540", AuthorId = Guid.Parse(Author2Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book3Id), Title = "The Shining", ISBN = "9780307743657", AuthorId = Guid.Parse(Author3Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book4Id), Title = "Harry Potter and the Chamber of Secrets", ISBN = "9780439064873", AuthorId = Guid.Parse(Author1Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book5Id), Title = "A Clash of Kings", ISBN = "9780553108033", AuthorId = Guid.Parse(Author2Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book6Id), Title = "It", ISBN = "9781501175460", AuthorId = Guid.Parse(Author3Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book7Id), Title = "Harry Potter and the Prisoner of Azkaban", ISBN = "9780439136365", AuthorId = Guid.Parse(Author1Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book8Id), Title = "A Storm of Swords", ISBN = "9780553106633", AuthorId = Guid.Parse(Author2Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book9Id), Title = "The Stand", ISBN = "9780307947307", AuthorId = Guid.Parse(Author3Id), Category = Category.Fiction },
            new Book { Id = Guid.Parse(Book10Id), Title = "Harry Potter and the Goblet of Fire", ISBN = "9780439139601", AuthorId = Guid.Parse(Author1Id), Category = Category.Fiction }
        );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User1Id), BookId = Guid.Parse(Book1Id), Rating = 5, Comment = "Loved it!", ReviewDate = new DateTime(2023, 1, 1) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User2Id), BookId = Guid.Parse(Book1Id), Rating = 4, Comment = "Great book!", ReviewDate = new DateTime(2023, 1, 2) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User3Id), BookId = Guid.Parse(Book2Id), Rating = 5, Comment = "Amazing!", ReviewDate = new DateTime(2023, 1, 3) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User4Id), BookId = Guid.Parse(Book3Id), Rating = 3, Comment = "It was okay.", ReviewDate = new DateTime(2023, 1, 4) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User5Id), BookId = Guid.Parse(Book4Id), Rating = 4, Comment = "Very good!", ReviewDate = new DateTime(2023, 1, 5) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User1Id), BookId = Guid.Parse(Book5Id), Rating = 5, Comment = "Excellent!", ReviewDate = new DateTime(2023, 1, 6) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User2Id), BookId = Guid.Parse(Book6Id), Rating = 4, Comment = "Really enjoyed it.", ReviewDate = new DateTime(2023, 1, 7) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User3Id), BookId = Guid.Parse(Book7Id), Rating = 5, Comment = "Fantastic!", ReviewDate = new DateTime(2023, 1, 8) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User4Id), BookId = Guid.Parse(Book8Id), Rating = 3, Comment = "Not bad.", ReviewDate = new DateTime(2023, 1, 9) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User5Id), BookId = Guid.Parse(Book9Id), Rating = 4, Comment = "Very interesting!", ReviewDate = new DateTime(2023, 1, 10) },
            new Review { Id = Guid.NewGuid(), UserId = Guid.Parse(User1Id), BookId = Guid.Parse(Book10Id), Rating = 5, Comment = "A must-read!", ReviewDate = new DateTime(2023, 1, 11) }
        );
    }
}