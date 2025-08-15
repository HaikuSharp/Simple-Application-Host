using SAH.Abstraction;
using SAH.SEB.Descripting;

namespace SAH.SEB.Extensions;

internal static class InternalEventBusExtensions
{
    internal static IServiceSource Source => field ??= new SingleServiceSource(EventBusDescriptor.Default);
}

