using SAH.Abstraction;

namespace SAH.SC.Extensions;

public static class ServiceRootExtensions
{
    public static IServiceRoot AppendConfiguration(this IServiceRoot root) => root.Append(InternalConfigurationExtensions.Source);
}

