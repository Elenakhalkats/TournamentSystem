using static TournamentSystem.Application.Exceptions.AppException;

namespace TournamentSystem.Application.Exceptions;

public class TeamNotFoundException : AppNotFoundException
{
    public TeamNotFoundException()
        : base("Team Not Found!")
    {

    }
}

