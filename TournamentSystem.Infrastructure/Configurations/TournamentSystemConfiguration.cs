using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;

namespace TournamentSystem.Infrastructure.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.Property(p => p.Name);
        builder.Property(p => p.HasParticipated);
        builder.Property(p => p.Rank);
        builder.HasOne(x => x.Team)
            .WithMany(x => x.Players)
            .HasForeignKey(x => x.TeamId);
    }
}
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.Property(p => p.TeamName);
        builder.Property(p => p.Rank);
    }
}
public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.Property(p => p.MatchRank)
            .HasDefaultValue(0);
        builder.Property(p => p.LostTeamId);
        builder.HasOne(x => x.Tournament)
            .WithMany(x => x.Matches)
            .HasForeignKey(x => x.TournamentId);
        builder.HasOne(x => x.WinnerTeam)
            .WithMany(x => x.Matches)
            .HasForeignKey(x => x.WinnerTeamId);
    }
}
public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.Property(p => p.StartDate);
        builder.Property(p => p.EndDate);
        builder.HasOne(p => p.WinnerTeam)
            .WithMany(p => p.WonTournaments)
            .HasForeignKey(p => p.WinnerTeamId);
    }
}
public class TournamentTeamConfiguration : IEntityTypeConfiguration<TournamentTeam>
{
    public void Configure(EntityTypeBuilder<TournamentTeam> builder)
    {
        builder.HasOne(p => p.Tournament)
            .WithMany(p => p.TournamentTeams)
            .HasForeignKey(p => p.TournamentId);
        builder.HasOne(p => p.Team)
            .WithMany(p => p.TournamentTeams)
            .HasForeignKey(p => p.TeamId);
    }
}