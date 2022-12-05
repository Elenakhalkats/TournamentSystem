using Newtonsoft.Json;

namespace TournamentSystem.Application.ResponseModels;

public class ExceptionResponse
{
    [JsonProperty(PropertyName = "statusCode")]
    public int StatusCode { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }
}
