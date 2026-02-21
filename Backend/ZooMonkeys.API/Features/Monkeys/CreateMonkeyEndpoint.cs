using FastEndpoints;
using Marten;
using ZooMonkeys.Domain.Monkeys;

namespace ZooMonkeys.API.Features.Monkeys;

public record CreateMonkeyRequest(string Name, int Age, Temperament Temperament);
public record CreateMonkeyResponse(MonkeyState Monkey);

public class CreateMonkeyEndpoint(IDocumentSession session) : Endpoint<CreateMonkeyRequest, CreateMonkeyResponse>
{
    public override void Configure()
    {
        Post("/api/monkeys");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateMonkeyRequest req, CancellationToken ct)
    {
        var id = Guid.NewGuid();
        var cmd = new RegisterMonkey(id, req.Name, req.Age, req.Temperament);
        
        // Load initial state for a new stream
        var state = MonkeyState.Initial;
        
        // Pure Function Processing
        var @event = MonkeyBehavior.Process(cmd, state);
        
        // Data Save
        session.Events.StartStream<MonkeyState>(id, @event);
        await session.SaveChangesAsync(ct);
        
        // Compute new state for response
        var newState = MonkeyBehavior.Apply(@event, state);
        await SendAsync(new CreateMonkeyResponse(newState), 201, ct);
    }
}
