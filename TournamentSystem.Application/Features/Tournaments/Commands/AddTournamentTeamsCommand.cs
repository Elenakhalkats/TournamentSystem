using AutoMapper;
using MediatR;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments.Queries;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Tournaments.Commands;

public sealed record AddTournamentTeamsCommand(Tournament Tournament, List<Team> Teams) : IRequest<GetTournament>
{
    public class AddTournamentTeamsCommandHandler : IRequestHandler<AddTournamentTeamsCommand, GetTournament>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMediator _mediator;
        public AddTournamentTeamsCommandHandler(ITournamentRepository tournamentRepository, IMediator mediator)
        {
            _tournamentRepository = tournamentRepository;
            _mediator = mediator;
        }

        public async Task<GetTournament> Handle(AddTournamentTeamsCommand request, CancellationToken cancellationToken)
        {
            var tournamentId = await _tournamentRepository.AddTournamentTeamsAsync(request.Tournament, request.Teams);
            var res = await _mediator.Send(new GetTeamsByTournamentIdQuery(tournamentId));
            return res;
        }
    }
}