using TournamentSystem.Application.Extentions;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Players;

public sealed class Player : Entity<int>
{
    public string Name { get; set; }
    public bool HasParticipated { get; set; }
    public int Rank { get; set; }
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    public Player()
    {

    }
    public static Player Create()
    {
        var player = new Player
        {
            Name = Generator.RandomString(4).ToLower(),
            HasParticipated = default,
            Rank = default
        };
        return player;
    }
}
public class GetPlayer
{
    public GetPlayer()
    {

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasParticipated { get; set; }
    public int Rank { get; set; }
}
