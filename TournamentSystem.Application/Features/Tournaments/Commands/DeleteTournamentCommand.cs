using MediatR;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features.Tournaments.Commands;

public sealed record DeleteTournamentCommand(int? Id) : IRequest<bool>
{
    public class DeleteTournamentCommandHandler : IRequestHandler<DeleteTournamentCommand, bool>
    {
        private readonly ITournamentRepository _tournamentRepository;
        public DeleteTournamentCommandHandler(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<bool> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            await _tournamentRepository.DeleteTournamentByIdAsync(request.Id);
            return true;
        }
    }

}
