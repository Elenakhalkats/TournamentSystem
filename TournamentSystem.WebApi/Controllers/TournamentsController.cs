using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentSystem.Application.Features.Matches.Commands;
using TournamentSystem.Application.Features.Matches.Queries;
using TournamentSystem.Application.Features.Tournaments.Commands;
using TournamentSystem.Application.Features.Tournaments.Queries;

namespace TournamentSystem.WebApi.Controllers;

[ApiController]
public class TournamentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TournamentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("GetPlayersByTournamentId")] 
    [Produces("application/json")]
    public async Task<IActionResult> GetPlayersByTournamentId([FromQuery] GetTeamsByTournamentIdQuery req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
    [HttpPost("GenerateTeamsForTournament")]
    public async Task<IActionResult> GenerateTeamsForTournament([FromQuery] GenerateTeamsForTournamentCommand req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
    [HttpDelete("DeleteTournamentById")]
    public async Task<IActionResult> DeleteTournamentById([FromQuery] DeleteTournamentCommand req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
    [HttpGet("GetMatches")]
    public async Task<IActionResult> GetMatchesByTournamentId([FromQuery] GetMatchesByTournamentIdQuery req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
    [HttpGet("PlayRound")]
    public async Task<IActionResult> PlayRound([FromQuery] PlayRoundCommand req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
    [HttpGet("EndTournament")]
    public async Task<IActionResult> EndTournament([FromQuery] EndTournamentCommand req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
}
