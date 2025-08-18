using SAH.Descripting;
using SAH.SC.Abstraction;

namespace SAH.SC.Descripting;

/// <summary>
/// Descriptor for the JSON configuration file resolver service.
/// </summary>
public sealed class JsonConfigurationFileResolverDescriptor : SingletonServiceDescriptorBase<IConfigurationFileResolver, JsonConfigurationFileResolver>
{
    /// <summary>
    /// Gets the default descriptor instance.
    /// </summary>
    public static JsonConfigurationFileResolverDescriptor Default => field ??= new();

    /// <inheritdoc/>
    protected override JsonConfigurationFileResolver GetServiceInstance() => JsonConfigurationFileResolver.Default;
}