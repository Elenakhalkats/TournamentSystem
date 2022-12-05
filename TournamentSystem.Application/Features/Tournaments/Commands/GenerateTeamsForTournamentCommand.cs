using MediatR;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Teams.Commands;

namespace TournamentSystem.Application.Features.Tournaments.Commands;

public sealed record GenerateTeamsForTournamentCommand(
    int NumOfPlayers = 3,
    int NumOfTeams = 4) : IRequest<GetTournament>
{
    public class GenerateTeamsForTournamentCommandHandler : IRequestHandler<GenerateTeamsForTournamentCommand, GetTournament>
    {
        private readonly IMediator _mediator;
        public GenerateTeamsForTournamentCommandHandler(IMediator mediator)
        {
            _mediator = mediator;   
        }
        public async Task<GetTournament> Handle(GenerateTeamsForTournamentCommand request, CancellationToken cancellationToken)
        {
            if (request.NumOfTeams % 2 != 0) throw new InvalidRequestException();
            var teams = await _mediator.Send(new GenerateTeamsCommand(request.NumOfPlayers, request.NumOfTeams));
            var tournament = new Tournament();
            var res = await _mediator.Send(new AddTournamentTeamsCommand(tournament, teams));
            return res;
        }
    }
}