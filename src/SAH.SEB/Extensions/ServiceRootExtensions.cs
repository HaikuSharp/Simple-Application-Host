using SAH.Abstraction;

namespace SAH.SEB.Extensions;

public static class ServiceRootExtensions
{
    public static IServiceRoot AppendEventBus(this IServiceRoot root) => root.Append(InternalEventBusExtensions.Source);
}

