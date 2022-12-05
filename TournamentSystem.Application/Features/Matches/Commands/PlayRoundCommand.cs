using AutoMapper;
using MediatR;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Matches.Commands;
public sealed record class PlayRoundCommand(int Id) : IRequest<List<GetTeam>>
{
    public class PlayRoundCommandHandler : IRequestHandler<PlayRoundCommand, List<GetTeam>>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public PlayRoundCommandHandler(IMatchRepository matchRepository, ITeamRepository teamRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<List<GetTeam>> Handle(PlayRoundCommand request, CancellationToken cancellationToken)
        {
            var tournamentId = request.Id;
            var teams = await _teamRepository.GetTeamsByTournamentIdAsync(tournamentId);

            var newTeams = teams.Where(x => teams.MaxBy(y => y.Rank).Rank.Equals(x.Rank)).ToList();
            var matches = await _matchRepository.PlayRoundAsync(newTeams, tournamentId);

            var res = _mapper.Map<List<GetTeam>>(matches.Select(x => x.WinnerTeam).ToList());
            return res;
        }
    }
}
