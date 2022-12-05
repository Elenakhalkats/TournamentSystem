using AutoMapper;
using MediatR;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Application.ResponseModels;

namespace TournamentSystem.Application.Features.Tournaments.Queries;

public sealed record GetTeamsByTournamentIdQuery(int Id) : IRequest<GetTournament>
{
    public class GetTeamsByTournamentIdQueryHandler : IRequestHandler<GetTeamsByTournamentIdQuery, GetTournament>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetTeamsByTournamentIdQueryHandler(ITournamentRepository tournamentRepository, ITeamRepository teamRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<GetTournament> Handle(GetTeamsByTournamentIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            if (id == default) throw new InvalidRequestException();
            var teams = await _teamRepository.GetTeamsByTournamentIdAsync(id);
            //if (teams) throw new TeamNotFoundException();
            var tournament = await _tournamentRepository.GetTournamentByIdAsync(id);
            
            var res = _mapper.Map<GetTournament>(tournament);
            res.Teams = _mapper.Map<List<GetTeam>>(teams);
            return res;
        }
    }
}
