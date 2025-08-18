using SAH.Abstraction;
using System.Reflection;

namespace SAH.Reflection.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IApplicationHost"/> working with assemblies.
/// </summary>
public static class ApplicationHostExtensions
{
    /// <summary>
    /// Loads services from the specified assembly into the application host.
    /// </summary>
    /// <param name="host">The application host.</param>
    /// <param name="assembly">The assembly containing service descriptors.</param>
    public static void Load(this IApplicationHost host, Assembly assembly) => host.Load(assembly.GetTypesAsServiceSource());

    /// <summary>
    /// Unloads services from the specified assembly from the application host.
    /// </summary>
    /// <param name="host">The application host.</param>
    /// <param name="assembly">The assembly containing service descriptors.</param>
    public static void UnloadEventBus(this IApplicationHost host, Assembly assembly) => host.Unload(assembly.GetTypesAsServiceSource());
}