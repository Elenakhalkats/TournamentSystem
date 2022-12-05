using Microsoft.EntityFrameworkCore;
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Infrastructure.Configurations;

namespace TournamentSystem.Infrastructure.Contexts;

public class TournamentSystemContext : DbContext
{
    public TournamentSystemContext(DbContextOptions options)
        : base(options)
    {

    }
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<TournamentTeam> TournamentTeams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
