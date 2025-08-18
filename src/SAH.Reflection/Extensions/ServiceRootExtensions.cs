using SAH.Abstraction;
using System.Reflection;

namespace SAH.Reflection.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IServiceBuilder"/> working with assemblies.
/// </summary>
public static class ServiceRootExtensions
{
    /// <summary>
    /// Appends service descriptors from the specified assembly to the service builder.
    /// </summary>
    /// <param name="root">The service builder.</param>
    /// <param name="assembly">The assembly containing service descriptors.</param>
    /// <returns>The service builder for chaining.</returns>
    public static IServiceBuilder Append(this IServiceBuilder root, Assembly assembly) => root.Append(assembly.GetTypesAsServiceSource());
}