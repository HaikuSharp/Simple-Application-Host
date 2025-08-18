using SAH.Abstraction;

namespace SAH.Extensions;

/// <summary>
/// Extension methods for application services.
/// </summary>
public static class ApplicationModuleExtensions
{
    /// <summary>
    /// Initializes the service if it hasn't been initialized yet.
    /// </summary>
    /// <param name="service">The service to initialize.</param>
    public static void IntitializeIfNeeded(this IApplicationService service)
    {
        if(service.IsInitialized) return;
        service.Initialize();
    }

    /// <summary>
    /// Deinitializes the service if it's currently initialized.
    /// </summary>
    /// <param name="service">The service to deinitialize.</param>
    public static void DeintitializeIfNeeded(this IApplicationService service)
    {
        if(!service.IsInitialized) return;
        service.Deinitialize();
    }
}