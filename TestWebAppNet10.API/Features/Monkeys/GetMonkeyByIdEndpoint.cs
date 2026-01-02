using FastEndpoints;
using FluentValidation;
using TestWebAppNet10.API.Common.Persistence;

namespace TestWebAppNet10.API.Features.Monkeys;

public record GetMonkeyRequest(Guid Id);

public record GetMonkeyResponse(Guid Id, string Name, int Age, string Temperament);

public class GetMonkeyByIdEndpoint(MonkeyRepository repository) : Endpoint<GetMonkeyRequest, GetMonkeyResponse>
{
    public override void Configure()
    {
        Get("/{Id}");
        Group<MonkeyGroup>();
    }

    public override async Task HandleAsync(GetMonkeyRequest req, CancellationToken ct)
    {
        var monkey = repository.GetById(req.Id);
        var response = new GetMonkeyResponse(
            monkey.Id,
            monkey.Name,
            monkey.Age,
            monkey.Temperament.ToString());

        await Send.OkAsync(response, ct);
    }

    public class GetMonkeyValidator : Validator<GetMonkeyRequest>
    {
        public GetMonkeyValidator()
        {
            RuleFor(request => request.Id)
                .Must(id => Guid.TryParse(id.ToString(), out id)).WithMessage("Id must be a valid guid");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        }
    }

    public class GetMonkeySummary : Summary<GetMonkeyByIdEndpoint>
    {
        public GetMonkeySummary()
        {
            Summary = "Get a monkey by id";
            Description = "Gets a monkey from the collection by id";

            Response(204, "Monkey found successfully");
            Response(400, "Invalid request data");
            Response(500, "Internal server error");

            ExampleRequest = new GetMonkeyRequest(Guid.NewGuid());
        }
    }
}