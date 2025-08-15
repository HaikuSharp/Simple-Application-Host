using SAH.Abstraction;

namespace SAH.SC.Extensions;

public static class ApplicationHostExtensions
{
    public static void LoadConfiguration(this IApplicationHost host) => host.Load(InternalConfigurationExtensions.Source);

    public static void UnloadConfiguration(this IApplicationHost host) => host.Unload(InternalConfigurationExtensions.Source);
}

