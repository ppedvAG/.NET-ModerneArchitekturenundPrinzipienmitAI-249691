namespace LibraryHub.Domain.Entities;

public class Loan : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
