using AutoMapper;
using MediatR;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Teams.Commands;
public sealed record GenerateTeamsCommand(
    int NumOfPlayers = 5,
    int NumOfTeams = 16) : IRequest<List<Team>>
{
    public class GenerateTeamsCommandHandler : IRequestHandler<GenerateTeamsCommand, List<Team>>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        public GenerateTeamsCommandHandler(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }
        public async Task<List<Team>> Handle(GenerateTeamsCommand request, CancellationToken cancellationToken)
        {
            var createTeams = new List<CreateTeam>();
            for (int i = 0; i < request.NumOfTeams; i++)
            {
                createTeams.Add(new CreateTeam(request.NumOfPlayers));
            }
            var teams = _mapper.Map<List<Team>>(createTeams);
            await _teamRepository.AddTeamsAsync(teams);
            return teams;
        }
    }
}
