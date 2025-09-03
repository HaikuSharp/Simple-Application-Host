using SAH.Abstraction;
using SC.Abstraction;
using System.Threading.Tasks;

namespace SAH.SC.Abstraction;

/// <summary>
/// Represents a service for managing configuration loading and saving.
/// </summary>
public interface IConfigurationService : IApplicationService
{
    /// <summary>
    /// Gets the root configuration.
    /// </summary>
    IConfiguration Root { get; }

    /// <summary>
    /// Loads configuration from current source.
    /// </summary>
    void Load();

    /// <summary>
    /// Save configuration to current source.
    /// </summary>
    void Save();

    /// <summary>
    /// Loads configuration from current source.
    /// </summary>
    Task LoadAsync();

    /// <summary>
    /// Save configuration to current source.
    /// </summary>
    Task SaveAsync();
}