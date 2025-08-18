using SAH.Abstraction;
using SAH.SEB.Descripting;

namespace SAH.SEB.Extensions;

/// <summary>
/// Internal extensions for event bus services.
/// </summary>
internal static class InternalEventBusExtensions
{
    /// <summary>
    /// Gets the default event bus service source.
    /// </summary>
    internal static IServiceSource Source => field ??= new SingleServiceSource(EventBusDescriptor.Default);
}