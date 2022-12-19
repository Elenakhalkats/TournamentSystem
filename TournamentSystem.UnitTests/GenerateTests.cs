using FluentAssertions;
using TournamentSystem.Application.Features.Teams;

namespace TournamentSystem.UnitTests;

public class GenerateTests
{
    [Fact]
    public void GenerateTeamsForTournament_IfNumberOfTeamsPasses_ShouldGenerateTeams()
    {
        var teams = new List<Team>();
        Random rnd = new();
        int num = rnd.Next(0, 100);

        for (int i = 0; i < num; i++)
        {
            teams.Add(Team.Create(2));
        }
       
        teams.Should().NotBeNull();
        teams.Should().HaveCount(num);
    }
}