using frich.Models;
using Microsoft.EntityFrameworkCore;

namespace frich.Data;

public class FrichDbContext : DbContext
{
    public FrichDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Person> Persons { get; set; } = default!;
}