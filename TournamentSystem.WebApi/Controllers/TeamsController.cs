using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentSystem.Application.Features;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams.Queries;

namespace TournamentSystem.WebApi.Controllers;

[ApiController]
public class TeamsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TeamsController(IMediator? mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("GetPlayersByTeamId")]
    [Produces("application/json")]
    public async Task<IActionResult> GetPlayersByTeamId([FromQuery] GetPlayersByTeamIdQuery req)
    {
        var result = await _mediator.Send(req);
        return Ok(result);
    }
    [HttpGet("GetPlayersByTeamIdtest")]
    public async Task<IActionResult> GetPlayersByTeamIdtest(TestQuery req)
    {
        //var result = new Player { Id = 1, HasParticipated = true, Rank = 2, Name = "player", TeamId = 1 };
        var result = await _mediator.Send(req);
        return Ok(result);
    }
}