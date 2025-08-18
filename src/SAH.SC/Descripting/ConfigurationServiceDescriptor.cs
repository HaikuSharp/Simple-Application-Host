using SAH.Descripting.Lazy;
using SAH.SC.Abstraction;
using SC.Abstraction;
using SDI.Abstraction;
using SDI.Extensions;

namespace SAH.SC.Descripting;

/// <summary>
/// Descriptor for the configuration service.
/// </summary>
public sealed class ConfigurationServiceDescriptor : LazySingletonServiceDescriptorBase<IConfigurationService>
{
    /// <summary>
    /// Gets the default descriptor instance.
    /// </summary>
    public static ConfigurationServiceDescriptor Default => field ??= new();

    /// <inheritdoc/>
    protected override IServiceInstanceActivator GetServiceActivator() => new ConfigurationServiceActivator();

    private class ConfigurationServiceActivator : IServiceInstanceActivator
    {
        /// <inheritdoc/>
        public object Activate(ServiceId requestedId, IServiceProvider provider) => new ConfigurationService(provider.GetRequiredService<IConfigurationFileResolver>(), provider.GetRequiredService<IConfigurationSettings>());
    }
}