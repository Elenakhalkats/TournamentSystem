
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;

namespace TournamentSystem.Application.Interfaces.Repositories;
public interface IMatchRepository
{
    Task<Tournament> GetMatchesByTournamentIdAsync(int? Id);
    Task<List<Match>> PlayRoundAsync(List<Team> Teams, int TournamentId);
}
