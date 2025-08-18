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
    public IConfigurationSource Resolve(string path) => new JsonFileConfigurationSource(path);
}