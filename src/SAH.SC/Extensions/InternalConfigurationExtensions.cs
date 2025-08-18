using SAH.Abstraction;
using SAH.SC.Descripting;

namespace SAH.SC.Extensions;

/// <summary>
/// Internal extensions for configuration services.
/// </summary>
internal static class InternalConfigurationExtensions
{
    /// <summary>
    /// Gets the default configuration service source.
    /// </summary>
    internal static IServiceSource Source => field ??= new ServiceSource(
    [
        ConfigurationServiceDescriptor.Default,
        ConfigurationSettingsDescriptor.Default,
        JsonConfigurationFileResolverDescriptor.Default
    ]);
}