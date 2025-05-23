namespace LibraryHub.Domain.Entities;

public class Review : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
}
