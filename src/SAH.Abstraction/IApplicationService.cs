namespace SAH.Abstraction;

public interface IApplicationService : IInitializable
{
    string Name { get; }

    int Order { get; }
}
