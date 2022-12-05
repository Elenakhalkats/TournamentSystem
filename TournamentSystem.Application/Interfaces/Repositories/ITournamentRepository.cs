using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;

namespace TournamentSystem.Application.Interfaces.Repositories;

public interface ITournamentRepository
{
    Task<Tournament> GetTournamentByIdAsync(int? Id);
    Task<int> AddTournamentTeamsAsync(Tournament Tournament, List<Team> Teams);
    Task<bool> UpdateTournamentAsync(int Id, int winnerTeamId);
    Task<bool> DeleteTournamentByIdAsync(int? Id);

}
