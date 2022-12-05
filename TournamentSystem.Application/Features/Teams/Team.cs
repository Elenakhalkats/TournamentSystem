using TournamentSystem.Application.Extentions;
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Teams;
public sealed class Team : Entity<int>
{
    public Team()
    {
            
    }
    public string TeamName { get; set; }
    public int Rank { get; set; }
    public List<TournamentTeam>? TournamentTeams { get; set; }
    public List<Tournament>? WonTournaments { get; set; }
    public List<Player>? Players { get; set; }
    public List<Match>? Matches { get; set; }
}
public class CreateTeam
{
    public CreateTeam(
        int numOfPlayers)
    {
        Players = GetNewPlayers(numOfPlayers);
        TeamName = Generator.RandomString(5);
        Rank = default;
    }
    public string TeamName { get; set; }
    public int Rank { get; set; }
    public List<NewPlayer>? Players { get; set; }
    private static List<NewPlayer> GetNewPlayers(int num)
    {
        var players = new List<NewPlayer>();
        for (int i = 0; i < num; i++)
        {
            players.Add(new NewPlayer());
        }
        return players;
    }
}
public class GetTeam
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Rank { get; set; }
    public List<GetPlayer>? Players { get; set; }
}

