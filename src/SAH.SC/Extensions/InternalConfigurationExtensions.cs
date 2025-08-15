using SAH.Abstraction;
using SAH.SC.Descripting;

namespace SAH.SC.Extensions;

internal static class InternalConfigurationExtensions
{
    internal static IServiceSource Source => field ??= new ServiceSource([ConfigurationServiceDescriptor.Default, ConfigurationSettingsDescriptor.Default, JsonConfigurationFileResolverDescriptor.Default]);
}
