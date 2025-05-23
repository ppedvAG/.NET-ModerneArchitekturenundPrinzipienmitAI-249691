using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitLibraryHubDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-5678-4e8f-8a9b-cdef01234567"), "J.K. Rowling" },
                    { new Guid("b2c3d4e5-6789-4f9a-8b0c-def012345678"), "George R.R. Martin" },
                    { new Guid("c3d4e5f6-7890-4a1b-9c2d-ef0123456789"), "Stephen King" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("1b9d6bcd-bbfd-4b2d-9b5d-ab8dfbbd4bed"), "peter@griffin.com", "Peter Griffin" },
                    { new Guid("2a35e6f1-4a6d-4e8f-8a9b-cdef01234567"), "leslie@knope.com", "Leslie Knope" },
                    { new Guid("68af4068-8e5a-4d7c-bc6e-9da9b0f41f9e"), "rick@sanchez.com", "Rick Sanchez" },
                    { new Guid("9c8b7a6d-5e4f-4a3b-2c1d-0e9f8a7b6c5d"), "michael@scott.com", "Michael Scott" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "homer@simpson.com", "Homer Simpson" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Category", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("0abc4567-1234-4394-9506-87bcdef01234"), new Guid("a1b2c3d4-5678-4e8f-8a9b-cdef01234567"), 0, "9780439139601", "Harry Potter and the Goblet of Fire" },
                    { new Guid("2d3e4f56-7890-4b1c-9d2e-0f3456789abc"), new Guid("b2c3d4e5-6789-4f9a-8b0c-def012345678"), 0, "9780553103540", "A Game of Thrones" },
                    { new Guid("3e4f5678-90ab-4c2d-9e3f-10456789abc0"), new Guid("c3d4e5f6-7890-4a1b-9c2d-ef0123456789"), 0, "9780307743657", "The Shining" },
                    { new Guid("4f567890-abcd-4d3e-8f40-2156789abcde"), new Guid("a1b2c3d4-5678-4e8f-8a9b-cdef01234567"), 0, "9780439064873", "Harry Potter and the Chamber of Secrets" },
                    { new Guid("567890ab-cdef-4e4f-9051-326789abcdef"), new Guid("b2c3d4e5-6789-4f9a-8b0c-def012345678"), 0, "9780553108033", "A Clash of Kings" },
                    { new Guid("67890abc-def0-4f50-9162-43789abcdef0"), new Guid("c3d4e5f6-7890-4a1b-9c2d-ef0123456789"), 0, "9781501175460", "It" },
                    { new Guid("7890abc1-ef01-4061-9273-5489abcdef01"), new Guid("a1b2c3d4-5678-4e8f-8a9b-cdef01234567"), 0, "9780439136365", "Harry Potter and the Prisoner of Azkaban" },
                    { new Guid("890abc23-f012-4172-9384-659abcdef012"), new Guid("b2c3d4e5-6789-4f9a-8b0c-def012345678"), 0, "9780553106633", "A Storm of Swords" },
                    { new Guid("90abc345-0123-4283-9495-76abcdef0123"), new Guid("c3d4e5f6-7890-4a1b-9c2d-ef0123456789"), 0, "9780307947307", "The Stand" },
                    { new Guid("b1d2e3f4-5678-4a9b-8c0d-ef1234567890"), new Guid("a1b2c3d4-5678-4e8f-8a9b-cdef01234567"), 0, "9780747532743", "Harry Potter and the Philosopher's Stone" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "Rating", "ReviewDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1eefff06-d222-4724-ac79-9ece80a2a3e0"), new Guid("2d3e4f56-7890-4b1c-9d2e-0f3456789abc"), "Amazing!", 5, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68af4068-8e5a-4d7c-bc6e-9da9b0f41f9e") },
                    { new Guid("254b8516-274b-42c6-82d9-b3f1062f741c"), new Guid("90abc345-0123-4283-9495-76abcdef0123"), "Very interesting!", 4, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c8b7a6d-5e4f-4a3b-2c1d-0e9f8a7b6c5d") },
                    { new Guid("3b746939-cbbc-49ba-a4b9-c6a2a4d19891"), new Guid("4f567890-abcd-4d3e-8f40-2156789abcde"), "Very good!", 4, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c8b7a6d-5e4f-4a3b-2c1d-0e9f8a7b6c5d") },
                    { new Guid("5b9de827-c14e-4092-b71f-884814917a4c"), new Guid("0abc4567-1234-4394-9506-87bcdef01234"), "A must-read!", 5, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479") },
                    { new Guid("658d06ca-e0a9-40b3-8998-48ede1753c55"), new Guid("3e4f5678-90ab-4c2d-9e3f-10456789abc0"), "It was okay.", 3, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a35e6f1-4a6d-4e8f-8a9b-cdef01234567") },
                    { new Guid("7145505f-fe6a-4eb7-a430-6512aa8e1587"), new Guid("67890abc-def0-4f50-9162-43789abcdef0"), "Really enjoyed it.", 4, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b9d6bcd-bbfd-4b2d-9b5d-ab8dfbbd4bed") },
                    { new Guid("771ce9d9-7757-4c61-8cc0-c66d97338750"), new Guid("b1d2e3f4-5678-4a9b-8c0d-ef1234567890"), "Loved it!", 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479") },
                    { new Guid("bf3b9d1f-921a-4631-bfed-084f10e15e23"), new Guid("890abc23-f012-4172-9384-659abcdef012"), "Not bad.", 3, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a35e6f1-4a6d-4e8f-8a9b-cdef01234567") },
                    { new Guid("c2e279e7-f5d6-45bc-959a-295c8aeaac7f"), new Guid("7890abc1-ef01-4061-9273-5489abcdef01"), "Fantastic!", 5, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68af4068-8e5a-4d7c-bc6e-9da9b0f41f9e") },
                    { new Guid("cc281e3d-14d2-43fd-a20b-ce5c52ee61ae"), new Guid("567890ab-cdef-4e4f-9051-326789abcdef"), "Excellent!", 5, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479") },
                    { new Guid("de443778-cf98-4a9f-bb27-e5d81f94afd9"), new Guid("b1d2e3f4-5678-4a9b-8c0d-ef1234567890"), "Great book!", 4, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b9d6bcd-bbfd-4b2d-9b5d-ab8dfbbd4bed") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
