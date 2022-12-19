using TournamentSystem.Application.Features.Teams;
using static TournamentSystem.Application.Exceptions.AppException;

namespace TournamentSystem.Application.Exceptions;

public class TournamentNotFoundException : AppNotFoundException
{
    public TournamentNotFoundException()
        : base("Tournament Not Found!")
    {

    }
}
public class TournamentDeniedException : AppDeniedException
{
    public TournamentDeniedException()
        : base("Tournament Can't Play More Rounds!")
    {

    }
}
