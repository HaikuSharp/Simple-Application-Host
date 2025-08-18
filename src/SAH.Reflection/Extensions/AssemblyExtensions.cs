using SAH.Abstraction;
using System.Reflection;

namespace SAH.Reflection.Extensions;

/// <summary>
/// Provides extension methods for <see cref="Assembly"/> to work with service sources.
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Creates a service source from all service descriptor types in the assembly.
    /// </summary>
    /// <param name="assembly">The assembly to scan for service descriptors.</param>
    /// <returns>A service source containing all found service descriptors.</returns>
    public static IServiceSource GetTypesAsServiceSource(this Assembly assembly) => new AssemblyDescriptorTypeServiceSource(assembly);
}