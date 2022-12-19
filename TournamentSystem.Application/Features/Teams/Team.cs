using Newtonsoft.Json;
using TournamentSystem.Application.Extentions;
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Teams;
public sealed class Team : Entity<int>
{
    public string TeamName { get; set; }
    public int Rank { get; set; }
    public List<TournamentTeam>? TournamentTeams { get; set; }
    public List<Tournament>? WonTournaments { get; set; }
    public List<Player>? Players { get; set; }
    public List<Match>? Matches { get; set; }
    public Team()
    {

    }
    public static Team Create(int? numOfPlayers)
    {
        var team = new Team
        {
            Players = GetNewPlayers(numOfPlayers),
            TeamName = Generator.RandomString(5),
            Rank = default
        };
        return team;
    }
    private static List<Player> GetNewPlayers(int? num)
    {
        var players = new List<Player>();
        for (int i = 0; i < num; i++)
        {
            players.Add(Player.Create());
        }
        return players;
    }
}
public class GetTeam
{
    [JsonProperty("Id")]
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Rank { get; set; }
    [JsonProperty("Players")]
    public List<GetPlayer>? Players { get; set; }
}

