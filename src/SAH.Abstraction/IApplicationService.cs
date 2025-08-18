namespace SAH.Abstraction;

/// <summary>
/// Represents an application service with initialization order.
/// </summary>
public interface IApplicationService : IInitializable
{
    /// <summary>
    /// Gets the service name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the initialization order.
    /// </summary>
    int Order { get; }
}