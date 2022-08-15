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
    public DbSet<Round> Rounds { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<ParticipantRoundScore> ParticipantRoundScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<ParticipantRoundScore>()
        //     .HasOne(p => p.Participant)
        //     .WithMany(prs => prs.ParticipantRoundScores)
        //     .HasForeignKey(p => p.ParticipantId);
        //
        // modelBuilder.Entity<ParticipantRoundScore>()
        //     .HasOne(p => p.Round)
        //     .WithMany(prs => prs.ParticipantRoundScores)
        //     .HasForeignKey(p => p.RoundId);

        modelBuilder.Entity<ParticipantRoundScore>().HasKey(p => new {p.ParticipantId, p.RoundId});
    }
}