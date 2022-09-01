using frich.Entities;
using Microsoft.EntityFrameworkCore;

namespace frich.Data;

public class FrichDbContext : DbContext
{
    public FrichDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Person> Persons { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<Participant> Participants { get; set; }


    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<ParticipantRound>().HasKey(p => new {p.ParticipantId, p.RoundId});
    // }
}