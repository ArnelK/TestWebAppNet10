using FastEndpoints;
using Marten;
using ZooMonkeys.Domain.Monkeys;

namespace ZooMonkeys.API.Features.Monkeys;

public record GetMonkeysResponse(IEnumerable<MonkeyState> Monkeys);

public class GetMonkeysEndpoint(IQuerySession session) : EndpointWithoutRequest<GetMonkeysResponse>
{
    public override void Configure()
    {
        Get("/api/monkeys");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var monkeys = await session.Query<MonkeyState>().Where(m => !m.IsDeleted).ToListAsync(ct);
        await SendAsync(new GetMonkeysResponse(monkeys), 200, ct);
    }
}
