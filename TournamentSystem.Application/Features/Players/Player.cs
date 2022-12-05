using TournamentSystem.Application.Extentions;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Primitive;

namespace TournamentSystem.Application.Features.Players;

public sealed class Player : Entity<int>
{
    public Player()
    {
    }
    public string Name { get; set; }
    public bool HasParticipated { get; set; }
    public int Rank { get; set; }
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
}
public class NewPlayer
{
    public NewPlayer()
    {
        Name = Generator.RandomString(4).ToLower();
        HasParticipated = default;
        Rank = default;
    }
    public string Name { get; set; }
    public bool HasParticipated { get; set; }
    public int Rank { get; set; }
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
