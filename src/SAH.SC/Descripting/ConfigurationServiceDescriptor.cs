using SAH.Descripting.Lazy;
using SAH.SC.Abstraction;
using SC.Abstraction;
using SDI.Abstraction;
using SDI.Extensions;

namespace SAH.SC.Descripting;

public sealed class ConfigurationServiceDescriptor : LazySingletonServiceDescriptorBase<IConfigurationService>
{
    public static ConfigurationServiceDescriptor Default => field ??= new();

    protected override IServiceInstanceActivator GetServiceActivator() => new ConfigurationServiceActivator();

    private class ConfigurationServiceActivator : IServiceInstanceActivator
    {
        public object Activate(ServiceId requestedId, IServiceProvider provider) => new ConfigurationService(provider.GetRequiredService<IConfigurationFileResolver>(), provider.GetRequiredService<IConfigurationSettings>());
    }
}
