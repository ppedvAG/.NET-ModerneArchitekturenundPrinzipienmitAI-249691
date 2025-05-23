using LibraryHub.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryHub.Domain.Entities;

public class Book : Entity
{
    [Column(TypeName = "varchar(100)")]
    public string Title { get; set; }

    [MaxLength(13)]
    public string ISBN { get; set; }

    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public Category Category { get; set; }
    public List<Loan> Loans { get; set; }
    public List<Review> Reviews { get; set; }
}
