using Marten.Events.Aggregation;
using ZooMonkeys.Domain.Monkeys;

namespace ZooMonkeys.API.Projections;

public class MonkeyStateProjection : SingleStreamProjection<MonkeyState, Guid>
{
    public MonkeyState Create(MonkeyRegistered e) => 
        MonkeyBehavior.Apply(e, MonkeyState.Initial);

    public MonkeyState Apply(IMonkeyEvent e, MonkeyState current) => 
        MonkeyBehavior.Apply(e, current);
}
