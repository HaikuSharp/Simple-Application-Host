using SAH.SC.Abstraction;
using SC.Abstraction;
using SC.Newtonsoft.JSON;

namespace SAH.SC;

/// <summary>
/// Provides JSON file resolution for configuration sources.
/// </summary>
public class JsonConfigurationFileResolver : IConfigurationFileResolver
{
    /// <summary>
    /// Gets the default instance of the JSON configuration file resolver.
    /// </summary>
    public static JsonConfigurationFileResolver Default => field ??= new();

    /// <inheritdoc/>
    public IFileConfigurationValueSource Resolve(string path, IConfigurationSettings settings) => new JsonFileConfigurationValueSource(path, settings);
}