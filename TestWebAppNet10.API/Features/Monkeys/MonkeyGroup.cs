using FastEndpoints;
using FastEndpoints.Swagger;

namespace TestWebAppNet10.API.Features.Monkeys;

public class MonkeyGroup : Group
{
    public MonkeyGroup()
    {
        Configure("/api/monkeys", endpointDefinition =>
        {
            endpointDefinition.Description(x => x
                .ProducesProblemDetails(500)
                .AutoTagOverride("Monkeys")
                .WithGroupName("Monkeys"));
            endpointDefinition.AllowAnonymous();
        });
    }
}