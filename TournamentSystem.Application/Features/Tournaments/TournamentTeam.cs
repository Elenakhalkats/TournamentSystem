using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Tournaments;

public sealed class TournamentTeam : Entity<int>
{
    public TournamentTeam()
    {
        //TournamentId = tournament.Id;
        //TeamId = team.Id;
    }

    public int? TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public int? TeamId { get; set; }
    public Team Team { get; set; }
}
public class GetTournamentTeam
{
    public GetTournamentTeam()
    {

    }
    public GetTeam Team { get; set; }
}