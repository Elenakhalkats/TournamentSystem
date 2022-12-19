using FluentAssertions;
using FluentValidation.TestHelper;
using TournamentSystem.Application.Features.Tournaments;
using TournamentSystem.Application.Features.Tournaments.Commands;

namespace TournamentSystem.UnitTests;

public class GenerateTeamsForTournamentCommandValidatorTests
{
	[Theory]
	[InlineData(0)]
	[InlineData(null)]
	[InlineData(-1)]
    public void GenerateTeamsForTournamentCommandValidator_IfNumOfPlayersIsNotAcceptable_ShouldThrowValidaionException(int? numOfPlayers)
	{
		var validator = new GenerateTeamsForTournamentCommandValidator();
		var generateTeamsForTournamentCommand = new GenerateTeamsForTournamentCommand(numOfPlayers, null);
		var result = validator.TestValidate(generateTeamsForTournamentCommand);
		result.ShouldHaveValidationErrorFor(x => x.numOfPlayers);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(null)]
    [InlineData(1)]
    public void GenerateTeamsForTournamentCommandValidator_IfNumOfTeamsIsNotAcceptable_ShouldThrowValidaionException(int? numOfTeams)
    {
        var validator = new GenerateTeamsForTournamentCommandValidator();
        var generateTeamsForTournamentCommand = new GenerateTeamsForTournamentCommand(null, numOfTeams);
        var result = validator.TestValidate(generateTeamsForTournamentCommand);
        result.ShouldHaveValidationErrorFor(x => x.numOfTeams);
    }
    [Theory]
    [InlineData(2, 2)]
    public void GenerateTeamsForTournamentCommandValidator_IfInputIsAcceptable_ShouldReturnGetTournamentModel(int numOfPlayers, int numOfTeams)
	{
        var validator = new GenerateTeamsForTournamentCommandValidator();
        var generateTeamsForTournamentCommand = new GenerateTeamsForTournamentCommand(numOfPlayers, numOfTeams);
        var result = validator.TestValidate(generateTeamsForTournamentCommand);
		result.IsValid.Should().BeTrue().GetType().IsAssignableFrom(typeof(GetTournament));
    }
}
