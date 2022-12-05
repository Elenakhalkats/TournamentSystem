using Microsoft.EntityFrameworkCore;
using System.Linq;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Infrastructure.Contexts;

namespace TournamentSystem.Infrastructure.Repositories;

public sealed class TeamRepository : ITeamRepository
{
    private readonly TournamentSystemContext _context;
    public TeamRepository(TournamentSystemContext context)
    {
        _context = context;
    }
    public async Task<List<Team>> AddTeamsAsync(List<Team> createTeams)
    {
        await _context.Teams.AddRangeAsync(createTeams);
        await _context.SaveChangesAsync();

        return createTeams;
    }
    public async Task<Team> GetPlayersByTeamIdAsync(int? Id)
    {
        var team = await _context.Teams
                .Where(x => x.Id == Id)
                .Include(x => x.Players)
                .FirstOrDefaultAsync();

        if (team == null) throw new TeamNotFoundException();
        return team;
    }
    public async Task<List<Team>> GetTeamsByTournamentIdAsync(int? Id)
    {
        var tournamentTeamsId = _context.TournamentTeams.Where(x => x.TournamentId == Id).Select(x => x.TeamId).ToList();
        if (!tournamentTeamsId.Any()) throw new TournamentNotFoundException();
        var teams = await _context.Teams
                .Where(x => tournamentTeamsId.Contains(x.Id))
                .Include(x => x.Players)
                .ToListAsync();
        return teams;
    }
}
