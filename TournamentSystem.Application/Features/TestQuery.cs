using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Application.Features;

public sealed record TestQuery : IRequest<Team>
{
    public class TestQueryHandler : IRequestHandler<TestQuery, Team>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TestQueryHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<Team> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            var res = await _teamRepository.GetPlayersByTeamIdTestAsync();
            return res;
        }

    }
}