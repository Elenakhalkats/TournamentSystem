using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentSystem.Application.Features.Teams.Queries;

namespace TournamentSystem.WebApi.Controllers;

[ApiController]
public class TeamsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TeamsController(IMediator mediator)
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
}