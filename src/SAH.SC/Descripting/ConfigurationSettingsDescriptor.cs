using SAH.Descripting;
using SC;
using SC.Abstraction;

namespace SAH.SC.Descripting;

/// <summary>
/// Descriptor for the configuration settings service.
/// </summary>
public sealed class ConfigurationSettingsDescriptor : SingletonServiceDescriptorBase<IConfigurationSettings, DefaultConfigurationSettings>
{
    /// <summary>
    /// Gets the default descriptor instance.
    /// </summary>
    public static ConfigurationSettingsDescriptor Default => field ??= new();

    /// <inheritdoc/>
    protected override DefaultConfigurationSettings GetServiceInstance() => DefaultConfigurationSettings.Default;
}