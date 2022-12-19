using AutoMapper;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;

namespace TournamentSystem.Application.Extentions;

public class Mappers : Profile
{
    public Mappers()
    {
        _ = CreateMap<Team, GetTeam>();
        _ = CreateMap<Player, GetPlayer>();
        _ = CreateMap<Tournament, GetTournament>();
        _ = CreateMap<GetTournamentMatches, Tournament>();
    }
}