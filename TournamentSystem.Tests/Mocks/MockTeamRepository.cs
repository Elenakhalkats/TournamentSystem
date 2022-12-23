using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSystem.Application.Features.Players;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Interfaces.Repositories;

namespace TournamentSystem.Tests.Mocks;

public static class MockTeamRepository
{
    public static Mock<ITeamRepository> GetTeamRepository()
    {
        var expectedObject = new Team
        {
            Id = 232,
            TeamName = "ETEYY",
            Rank = 0
        };
        var mockRepo = new Mock<ITeamRepository>();
        mockRepo.Setup(x => x.GetPlayersByTeamIdTestAsync()).ReturnsAsync(expectedObject);
        mockRepo.Setup(x => x.AddTeamsAsync(It.IsAny<List<Team>>()));
        return mockRepo;
    }
}
