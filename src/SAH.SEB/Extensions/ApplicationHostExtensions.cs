using SAH.Abstraction;

namespace SAH.SEB.Extensions;

public static class ApplicationHostExtensions
{
    public static void LoadEventBus(this IApplicationHost host) => host.Load(InternalEventBusExtensions.Source);

    public static void UnloadEventBus(this IApplicationHost host) => host.Unload(InternalEventBusExtensions.Source);
}

