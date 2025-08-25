using SDI.Abstraction;
using IServiceProvider = SDI.Abstraction.IServiceProvider;

namespace SAH.Abstraction;

/// <summary>
/// Represents an application host that manages service lifecycle.
/// </summary>
public interface IApplicationHost : IInitializable
{
    /// <summary>
    /// Gets the service controller.
    /// </summary>
    IServiceController Controller { get; }

    /// <summary>
    /// Loads services from the specified source.
    /// </summary>
    /// <param name="source">The service source.</param>
    void Load(IServiceSource source);

    /// <summary>
    /// Unloads services from the specified source.
    /// </summary>
    /// <param name="source">The service source.</param>
    void Unload(IServiceSource source);
}