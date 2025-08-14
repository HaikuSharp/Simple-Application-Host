using SAH.Abstraction;

namespace SAH.SEB.Extensions;

internal static class InternalEventBusExtensions
{
    internal static IServiceSource Source => field ??= new SingleServiceSource(new EventBusDescriptor());
}

