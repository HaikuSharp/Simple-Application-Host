using SC.Abstraction;

namespace SAH.SC.Abstraction;

/// <summary>
/// Represents a resolver for configuration files.
/// </summary>
public interface IConfigurationFileResolver
{
    /// <summary>
    /// Resolves a configuration values source from the specified file path.
    /// </summary>
    /// <param name="path">The path to the configuration file.</param>
    /// <param name="settings">The configuration settings.</param>
    /// <returns>The resolved configuration source.</returns>
    IFileConfigurationValueSource Resolve(string path, IConfigurationSettings settings);
}