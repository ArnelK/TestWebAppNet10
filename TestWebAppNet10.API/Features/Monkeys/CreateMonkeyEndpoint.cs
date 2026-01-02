using FastEndpoints;
using FluentValidation;
using TestWebAppNet10.API.Common.Domain.Monkeys;
using TestWebAppNet10.API.Common.Persistence;
using TestWebAppNet10.API.Features.Monkeys.Commands;
using TestWebAppNet10.API.Features.Monkeys.Events;

namespace TestWebAppNet10.API.Features.Monkeys;

public record CreateMonkeyRequest(string Name, int Age, Temperament Temperament);

public class CreateMonkeyValidator : Validator<CreateMonkeyRequest>
{
    public CreateMonkeyValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Age).GreaterThan(0);
        RuleFor(x => x.Temperament)
            .IsInEnum()
            .WithMessage("Temperament must be a valid value.");
    }
}

public record CreateMonkeyResponse(Guid Id, string Name, int Age, string Temperament);

public class CreateMonkeyEndpoint(MonkeyRepository repository)
    : Endpoint<CreateMonkeyRequest, CreateMonkeyResponse>
{
    public override void Configure()
    {
        Post("");
        Group<MonkeyGroup>();
    }

    public override async Task HandleAsync(CreateMonkeyRequest req, CancellationToken ct)
    {
        var monkeyCount = repository.GetAll().Count;

        //demonstration
        if (monkeyCount >= 5)
        {
            AddError("Monkey limit reached. Cannot add more monkeys.");
            await Send.ErrorsAsync(cancellation: ct);
            return;
        }

        var monkey = Monkey.Create(req.Name, req.Age, req.Temperament);
        repository.Create(monkey);

        var response = new CreateMonkeyResponse(
            monkey.Id,
            monkey.Name,
            monkey.Age,
            monkey.Temperament.ToString());

        await Send.CreatedAtAsync<GetMonkeyByIdEndpoint>(
            new { id = monkey.Id },
            response,
            cancellation: ct);

        await new MonkeyCreatedEvent(req.Name, req.Age).PublishAsync(Mode.WaitForAll, ct);

        await new EmailZooCommand(req.Name, req.Age).ExecuteAsync(ct);
    }

    public class CreateMonkeySummary : Summary<CreateMonkeyEndpoint>
    {
        public CreateMonkeySummary()
        {
            Summary = "Create a new monkey";
            Description = "Adds a new monkey to the collection. The system has a maximum limit of 5 monkeys.";

            Response(204, "Monkey created successfully");
            Response(400, "Invalid request data or monkey limit reached");
            Response(500, "Internal server error");

            ExampleRequest = new CreateMonkeyRequest(
                "Bubbles",
                4,
                Temperament.Playful
            );
        }
    }
}