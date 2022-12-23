using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TournamentSystem.Application.Extentions;
using TournamentSystem.Application.Features;
using TournamentSystem.Application.Features.Teams;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Tests.Mocks;
using static TournamentSystem.Application.Features.TestQuery;

namespace TournamentSystem.Tests.Queries;

public class GetPlayersByTeamIdRequestHandlerTests
{
    private readonly Mock<ITeamRepository> _mockRepo;
    private readonly IMapper _mapper;
    public GetPlayersByTeamIdRequestHandlerTests()
	{
		_mockRepo = MockTeamRepository.GetTeamRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<Mappers>();
        });
        _mapper = mapperConfig.CreateMapper(); 
    }
    [Fact]
    public async Task GetPlayersByTeamIdTest_ReturnsTeam()
    {
        var handler = new TestQueryHandler(_mockRepo.Object, _mapper);
        var result = await handler.Handle(new TestQuery(), CancellationToken.None);
        result.ShouldBeOfType<Team>();
        result.ShouldNotBeNull();
    }
}
