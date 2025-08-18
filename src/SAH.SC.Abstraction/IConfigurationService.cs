using SC.Abstraction;

namespace SAH.SC.Abstraction;

/// <summary>
/// Represents a handler for configuration root save events.
/// </summary>
/// <param name="root">The configuration root that was saved.</param>
public delegate void ConfigurationRootSaveHandler(IConfigurationRoot root);

/// <summary>
/// Represents a handler for configuration root load events.
/// </summary>
/// <param name="root">The configuration root that was loaded.</param>
public delegate void ConfigurationRootLoadHandler(IConfigurationRoot root);

/// <summary>
/// Represents a service for managing configuration loading and saving.
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Occurs when a configuration root is saved.
    /// </summary>
    event ConfigurationRootSaveHandler OnRootSaved;

    /// <summary>
    /// Occurs when a configuration root is loaded.
    /// </summary>
    event ConfigurationRootLoadHandler OnRootLoaded;

    /// <summary>
    /// Gets the root configuration.
    /// </summary>
    IConfigurationRoot Root { get; }

    /// <summary>
    /// Gets a value indicating whether the configuration is loaded.
    /// </summary>
    bool IsLoaded { get; }
}