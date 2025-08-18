using SAH.Abstraction;

namespace SAH.SC.Extensions;

/// <summary>
/// Provides extension methods for application hosts to work with configuration services.
/// </summary>
public static class ApplicationHostExtensions
{
    /// <summary>
    /// Loads the configuration services into the application host.
    /// </summary>
    /// <param name="host">The application host.</param>
    public static void LoadConfiguration(this IApplicationHost host) => host.Load(InternalConfigurationExtensions.Source);

    /// <summary>
    /// Unloads the configuration services from the application host.
    /// </summary>
    /// <param name="host">The application host.</param>
    public static void UnloadConfiguration(this IApplicationHost host) => host.Unload(InternalConfigurationExtensions.Source);
}