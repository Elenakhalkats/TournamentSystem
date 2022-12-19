using FluentValidation;
using MediatR;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Teams.Commands;

namespace TournamentSystem.Application.Features.Tournaments.Commands;
public sealed record GenerateTeamsForTournamentCommand(
    int? numOfPlayers,
    int? numOfTeams) : IRequest<GetTournament>
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
            var validate = new GenerateTeamsForTournamentCommandValidator();
            if (!validate.Validate(request).IsValid) throw new InvalidRequestException();
            var teams = await _mediator.Send(new GenerateTeamsCommand(request.numOfPlayers, request.numOfTeams), cancellationToken);
            var tournament = new Tournament();
            var res = await _mediator.Send(new AddTournamentTeamsCommand(tournament, teams), cancellationToken);
            return res;
        }
    }
}
public class GenerateTeamsForTournamentCommandValidator : AbstractValidator<GenerateTeamsForTournamentCommand>
{
    public GenerateTeamsForTournamentCommandValidator()
    {
        RuleFor(x => x.numOfPlayers)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(1).WithMessage("The number of players must be minimum 1!")
            .GetType()
            .IsAssignableFrom(typeof(int));
        RuleFor(x => x.numOfTeams)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(2).WithMessage("The number of teams must be minimum 2!")
            .Must(numOfTeams => IsEven(numOfTeams)).WithMessage("The number of teams must be even!")
            .GetType()
            .IsAssignableFrom(typeof(int));
    }
    private static bool IsEven(int? num)
    {
        return num % 2 == 0;
    }
}