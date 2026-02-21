using FastEndpoints;
using Marten;
using ZooMonkeys.Domain.Monkeys;

namespace ZooMonkeys.API.Features.Monkeys;

public record GetMonkeyRequest(Guid Id);

public class GetMonkeyEndpoint(IQuerySession session) : Endpoint<GetMonkeyRequest, MonkeyState>
{
    public override void Configure()
    {
        Get("/api/monkeys/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetMonkeyRequest req, CancellationToken ct)
    {
        var monkey = await session.LoadAsync<MonkeyState>(req.Id, ct);
        if (monkey == null || monkey.IsDeleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(monkey, 200, ct);
    }
}
