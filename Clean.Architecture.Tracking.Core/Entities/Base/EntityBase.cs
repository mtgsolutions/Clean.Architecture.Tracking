namespace Clean.Architecture.Tracking.Core.Entities.Base;

public class EntityBase
{
    public EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}
