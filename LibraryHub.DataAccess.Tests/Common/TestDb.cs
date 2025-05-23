using Microsoft.EntityFrameworkCore;

namespace LibraryHub.DataAccess.Tests.Common;

//public class TestDbContext : LibraryHubDbContext

// Statt den LibraryHubDbContext zu erweitern, koennen wir den cast operator ueberladen
public class TestDb : IDisposable
{
    private const string ConnectionString = "Server=(localdb)\\SWArch250523;Database=UnitTests_{0};Trusted_Connection=True;MultipleActiveResultSets=true";

    private LibraryHubDbContext _context;

    public LibraryHubDbContext Context => _context ??= CreateDbContext();

    public LibraryHubDbContext CreateDbContext()
    {
        string id = Guid.NewGuid().ToString()[^4..];
        var options = new DbContextOptionsBuilder<LibraryHubDbContext>()
            .UseSqlServer(string.Format(ConnectionString, id))
            .Options;

        var context = new LibraryHubDbContext(options);

        // Datenbank wird erstellt
        //context.Database.EnsureCreated();

        // Datenbank erstellen und migrieren
        context.Database.Migrate();

        return context;
    }

    public void Dispose()
    {
        _context?.Database.EnsureDeleted();
        _context?.Dispose();
    }

    // Ueberladung des cast-Operators
    public static implicit operator LibraryHubDbContext(TestDb testDb) 
        => testDb.Context;
}
