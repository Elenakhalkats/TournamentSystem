using Microsoft.EntityFrameworkCore;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Infrastructure.Contexts;

namespace TournamentSystem.Infrastructure.Repositories;

public class TournamentRepository : ITournamentRepository
{
    private readonly TournamentSystemContext _context;
    public TournamentRepository(TournamentSystemContext context)
    {
        _context = context;
    }
    public async Task<Tournament> GetTournamentByIdAsync(int? Id)
    {
        var res = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == Id);
        return res;
    }
    public async Task<int> AddTournamentTeamsAsync(Tournament Tournament, List<Team> Teams)
    {
        await _context.Tournaments.AddAsync(Tournament);
        await _context.SaveChangesAsync();
        
        foreach (var team in Teams)
        {
            var tournamentTeam = new TournamentTeam() { Tournament = Tournament, Team = team };
            await _context.TournamentTeams.AddAsync(tournamentTeam);
        }
        await _context.SaveChangesAsync();

        return Tournament.Id;
    }
    public async Task<bool> UpdateTournamentAsync(int Id, int winnerTeamId)
    {
        var tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == Id);
        if (tournament == null) throw new TournamentNotFoundException();
        tournament.WinnerTeam = _context.Teams.FirstOrDefault(x => x.Id == winnerTeamId);
        _context.Tournaments.Update(tournament);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteTournamentByIdAsync(int? Id)
    {
        var tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == Id);
        if (tournament == null) throw new TournamentNotFoundException();

        _context.Tournaments.RemoveRange(tournament);
        
        await _context.SaveChangesAsync();
        return true;
    }
}
