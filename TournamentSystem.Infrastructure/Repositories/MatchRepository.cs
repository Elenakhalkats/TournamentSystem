using Microsoft.EntityFrameworkCore;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Extentions;
using TournamentSystem.Application.Features.Matches;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Infrastructure.Contexts;

namespace TournamentSystem.Infrastructure.Repositories;

public class MatchRepository : IMatchRepository
{
    private readonly TournamentSystemContext _context;
    public MatchRepository(TournamentSystemContext context)
    {
        _context = context;
    }

    public async Task<Tournament> GetMatchesByTournamentIdAsync(int? Id)
    {
        var tournamentMatches = await _context.Tournaments
            .Where(x => x.Id == Id)
            .Include(x => x.Matches)
            .FirstOrDefaultAsync();

        if (tournamentMatches == null) throw new TournamentNotFoundException();
        return tournamentMatches;
    }

    public async Task<List<Match>> PlayRoundAsync(List<Team> teams, int tournamentId) 
    {
        var matches = new List<Match>();
        var numOfTeams = teams.Count;

        if (numOfTeams == 1) throw new TournamentDeniedException();

        for (int i = 0; i < numOfTeams - 1; i += 2)
        {
            var firstTeam = teams[i];
            var secondTeam = teams[i+1];

            if (Generator.RandomBool())
            {
                firstTeam.Rank += 1;
                matches.Add(new Match() { WinnerTeam = firstTeam, LostTeamId = secondTeam.Id, MatchRank = firstTeam.Rank, TournamentId = tournamentId });
            } else
            {
                secondTeam.Rank += 1;
                matches.Add(new Match() { WinnerTeam = secondTeam, LostTeamId = firstTeam.Id, MatchRank = secondTeam.Rank, TournamentId = tournamentId });
            }
            _context.Teams.UpdateRange(firstTeam, secondTeam);
            await _context.SaveChangesAsync();
        }
        await _context.Matches.AddRangeAsync(matches);
        await _context.SaveChangesAsync();

        return matches;
    }
}