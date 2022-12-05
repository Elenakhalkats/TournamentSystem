using AutoMapper;
using MediatR;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Matches.Queries;
public sealed record GetMatchesByTournamentIdQuery(int? Id) : IRequest<GetTournamentMatches>
{
    public class GetMatchesByTournamentIdQueryHandler : IRequestHandler<GetMatchesByTournamentIdQuery, GetTournamentMatches>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;
        public GetMatchesByTournamentIdQueryHandler(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<GetTournamentMatches> Handle(GetMatchesByTournamentIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            if (id == default) throw new InvalidRequestException();

            var tournamentMatches = await _matchRepository.GetMatchesByTournamentIdAsync(id);

            var res = _mapper.Map<GetTournamentMatches>(tournamentMatches);
            return res;
        }
    }
}
