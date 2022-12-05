using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TournamentSystem.Application.Exceptions;
using TournamentSystem.Application.Interfaces.Repositories;
using TournamentSystem.Infrastructure.Contexts;
using TournamentSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(IPlayerRepository).Assembly);
builder.Services.AddMediatR(typeof(ITeamRepository).Assembly);
builder.Services.AddMediatR(typeof(ITournamentRepository).Assembly);

builder.Services.AddDbContext<TournamentSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TournamentSystemDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<AppExceptionHandler>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
