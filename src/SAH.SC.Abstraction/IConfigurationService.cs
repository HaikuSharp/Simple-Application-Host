using SAH.Abstraction;
using SC.Abstraction;

namespace SAH.SC.Abstraction;

/// <summary>
/// Represents a service for managing configuration loading and saving.
/// </summary>
public interface IConfigurationService : IApplicationService, IConfigurationRoot
{
    /// <summary>
    /// Gets the root configuration.
    /// </summary>
    IConfigurationRoot Root { get; }
}