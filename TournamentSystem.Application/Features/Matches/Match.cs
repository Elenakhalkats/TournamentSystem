using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Matches;

public sealed class Match : Entity<int>
{
    public int MatchRank { get; set; }
    public int? TournamentId { get; set; }
    public Tournament? Tournament { get; set; }
    public int? WinnerTeamId { get; set; }
    public Team? WinnerTeam { get; set; }
    public int? LostTeamId { get; set; }
}