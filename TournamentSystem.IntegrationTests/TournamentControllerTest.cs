using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net.Http.Json;
using TournamentSystem.Application.Features.Tournaments.Commands;

namespace TournamentSystem.IntegrationTests;

public class TournamentControllerTest
{
    protected readonly HttpClient _httpClient;
    public TournamentControllerTest()
    {
        var appFactory = new WebApplicationFactory<Program>();
        _httpClient = appFactory.CreateClient();
    }
    [Fact]
    public async void Generate_Tournament_Post()
    {
        var url = "";
        var response = await _httpClient.PostAsJsonAsync(url, new GenerateTeamsForTournamentCommand(1, 4));
        
    }
}