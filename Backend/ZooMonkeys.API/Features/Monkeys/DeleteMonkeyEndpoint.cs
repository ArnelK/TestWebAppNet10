using FastEndpoints;
using Marten;
using ZooMonkeys.Domain.Monkeys;

namespace ZooMonkeys.API.Features.Monkeys;

public record DeleteMonkeyRequest(Guid Id);

public class DeleteMonkeyEndpoint(IDocumentSession session) : Endpoint<DeleteMonkeyRequest>
{
    public override void Configure()
    {
        Delete("/api/monkeys/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteMonkeyRequest req, CancellationToken ct)
    {
        // Load latest state from EventStream to enforce strong consistency
        var state = await session.Events.AggregateStreamAsync<MonkeyState>(req.Id, token: ct);
        if (state == null || state.IsDeleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var cmd = new DeleteMonkey(req.Id);
        
        // Pure Function
        var @event = MonkeyBehavior.Process(cmd, state);
        
        // Save Event
        session.Events.Append(req.Id, @event);
        await session.SaveChangesAsync(ct);
        
        await SendNoContentAsync(ct);
    }
}
