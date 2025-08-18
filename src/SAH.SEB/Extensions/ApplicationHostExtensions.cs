using SAH.Abstraction;

namespace SAH.SEB.Extensions;

/// <summary>
/// Provides extension methods for application hosts to work with event bus services.
/// </summary>
public static class ApplicationHostExtensions
{
    /// <summary>
    /// Loads the event bus service into the application host.
    /// </summary>
    /// <param name="host">The application host.</param>
    public static void LoadEventBus(this IApplicationHost host) => host.Load(InternalEventBusExtensions.Source);

    /// <summary>
    /// Unloads the event bus service from the application host.
    /// </summary>
    /// <param name="host">The application host.</param>
    public static void UnloadEventBus(this IApplicationHost host) => host.Unload(InternalEventBusExtensions.Source);
}