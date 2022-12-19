using AutoMapper;
using MediatR;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Teams.Commands;
public sealed record GenerateTeamsCommand(
    int? NumOfPlayers,
    int? NumOfTeams) : IRequest<List<Team>>
{
    public class GenerateTeamsCommandHandler : IRequestHandler<GenerateTeamsCommand, List<Team>>
    {
        private readonly ITeamRepository _teamRepository;
        public GenerateTeamsCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<List<Team>> Handle(GenerateTeamsCommand request, CancellationToken cancellationToken)
        {
            var teams = new List<Team>();
            for (int i = 0; i < request.NumOfTeams; i++)
            {
                teams.Add(Team.Create(request.NumOfPlayers));
            }
            await _teamRepository.AddTeamsAsync(teams);
            return teams;
        }
    }
}
