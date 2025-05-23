namespace LibraryHub.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Loan> Loans { get; set; }
    public List<Review> Reviews { get; set; }
}
