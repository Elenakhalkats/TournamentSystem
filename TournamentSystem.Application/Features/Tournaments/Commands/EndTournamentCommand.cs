using MediatR;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Matches.Commands;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Tournaments.Commands;

public sealed record EndTournamentCommand(int Id) : IRequest<GetTeam>
{
    public class EndTournamentCommandHandler : IRequestHandler<EndTournamentCommand, GetTeam>
    {
        private readonly IMediator _mediator;
        private readonly ITournamentRepository _tournamentRepository;

        public EndTournamentCommandHandler(IMediator mediator, ITournamentRepository tournamentRepository)
        {
            _mediator = mediator;
            _tournamentRepository = tournamentRepository;
        }
        public async Task<GetTeam> Handle(EndTournamentCommand request, CancellationToken cancellationToken)
        {
            var tournament = await _tournamentRepository.GetTournamentByIdAsync(request.Id);
            if (tournament.WinnerTeam != null) throw new InvalidRequestException();
            var teams = new List<GetTeam>();
            do
            {
                teams = await _mediator.Send(new PlayRoundCommand(request.Id));
            } while (teams.Count != 1);
            var winnerTeam = teams.First();
            await _tournamentRepository.UpdateTournamentAsync(request.Id, winnerTeam.Id);
            return winnerTeam;
        }
    }
}
