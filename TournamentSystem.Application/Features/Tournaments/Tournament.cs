using Newtonsoft.Json;
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Tournaments;

public sealed class Tournament : Entity<int>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? WinnerTeamId { get; set; }
    public Team? WinnerTeam { get; set; }
    public List<TournamentTeam>? TournamentTeams { get; set; }
    public List<Match>? Matches { get; set; }
}
public class GetTournament
{
    [JsonProperty("Id")]
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? WinnerTeamId { get; set; }
    public Team? WinnerTeam { get; set; }
    [JsonProperty("Teams")]
    public List<GetTeam>? Teams { get; set; }
}
public class GetTournamentMatches
{
    public GetTournamentMatches()
    {

    }
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public List<Match>? Matches { get; set; }
}
