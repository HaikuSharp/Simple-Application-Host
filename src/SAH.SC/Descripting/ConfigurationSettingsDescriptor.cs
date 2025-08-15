using SAH.Descripting;
using SC;
using SC.Abstraction;

namespace SAH.SC.Descripting;

public sealed class ConfigurationSettingsDescriptor : SingletonServiceDescriptorBase<IConfigurationSettings, DefaultConfigurationSettings>
{
    public static ConfigurationSettingsDescriptor Default => field ??= new();

    protected override DefaultConfigurationSettings GetServiceInstance() => DefaultConfigurationSettings.Default;
}
