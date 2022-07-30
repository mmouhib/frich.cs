using frich.Entities;
using Microsoft.EntityFrameworkCore;

namespace frich.Data;

public class FrichDbContext : DbContext
{
    public FrichDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Person> Persons { get; set; } = default!;
    public DbSet<Match> Matches { get; set; } = default!;
}