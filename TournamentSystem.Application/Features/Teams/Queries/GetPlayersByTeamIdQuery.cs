using AutoMapper;
using MediatR;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Application.ResponseModels;

namespace TournamentSystem.Application.Features.Teams.Queries;
public sealed record GetPlayersByTeamIdQuery(int Id) : IRequest<GetTeam>
{
    public class GetPlayersByTeamIdQueryHandler : IRequestHandler<GetPlayersByTeamIdQuery, GetTeam>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetPlayersByTeamIdQueryHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<GetTeam> Handle(GetPlayersByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            if (id == default) throw new InvalidRequestException();

            var teamPlayers = await _teamRepository.GetPlayersByTeamIdAsync(id);
            var res = _mapper.Map<GetTeam>(teamPlayers);
            return res;
        }
    }
}
