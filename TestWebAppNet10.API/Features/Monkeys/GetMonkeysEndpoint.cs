using FastEndpoints;
using TestWebAppNet10.API.Common.Persistence;

namespace TestWebAppNet10.API.Features.Monkeys;

public record GetMonkeysResponse(List<GetMonkeysResponse.MonkeyDto> Monkeys)
{
    public record MonkeyDto(Guid Id, string Name, int Age, string Temperament);
}

public class GetMonkeysEndpoint(MonkeyRepository repository)
    : EndpointWithoutRequest<GetMonkeysResponse>
{
    public override void Configure()
    {
        Get("");
        Group<MonkeyGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var monkeys = repository.GetAll()
            .Select(m => new GetMonkeysResponse.MonkeyDto(
                m.Id,
                m.Name,
                m.Age,
                m.Temperament.ToString()))
            .ToList();

        await Send.OkAsync(new GetMonkeysResponse(monkeys), ct);
    }

    public class GetMonkeysSummary : Summary<GetMonkeysEndpoint>
    {
        public GetMonkeysSummary()
        {
            Summary = "Get monkeys";
            Description = "Gets monkeys as collection. The system has a maximum limit of 5 monkeys.";

            Response(200, "Monkeys found successfully");
            Response(500, "Internal server error");
        }
    }
}