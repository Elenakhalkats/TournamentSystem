using Microsoft.EntityFrameworkCore;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Infrastructure.Contexts;

namespace TournamentSystem.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly TournamentSystemContext _context;
    public PlayerRepository(TournamentSystemContext context)
    {
        _context = context;
    }
    //public async Task<bool> AddPlayersForTournamentAsync()
    //{
    //    return true;
    //}

    //public async Task<Tournament> GetTeamsByTournamentIdAsync(int? Id)
    //{
    //    var tournament = _context.Tournaments
    //        .Where(x => x.Id == Id)
    //        .Include(x => x.TournamentTeams)
    //        .FirstOrDefault();

    //    if(tournament == null) throw new TournamentNotFoundException();
    //    return tournament;
    //}
}
