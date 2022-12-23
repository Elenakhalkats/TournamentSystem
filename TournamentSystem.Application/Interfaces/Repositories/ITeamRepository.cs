using TournamentSystem.Application.Features.Teams;

namespace TournamentSystem.Application.Interfaces.Repositories;

public interface ITeamRepository
{
    Task<Team> GetPlayersByTeamIdAsync(int? Id);
    Task<Team> GetPlayersByTeamIdTestAsync();
    Task<List<Team>> GetTeamsByTournamentIdAsync(int? Id);
    Task<List<Team>> AddTeamsAsync(List<Team> teams);
}
