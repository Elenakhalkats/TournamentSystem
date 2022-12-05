using static TournamentSystem.Application.Exceptions.AppException;

namespace TournamentSystem.Application.Exceptions;

public class TournamentNotFoundException : AppNotFoundException
{
    public TournamentNotFoundException()
        : base("Tournament Not Found!")
    {

    }
}
