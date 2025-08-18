using SAH.Abstraction;
using SDI.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SAH.Reflection;

/// <summary>
/// Represents a service source that discovers and creates service descriptors from an assembly.
/// </summary>
public sealed class AssemblyDescriptorTypeServiceSource(Assembly assembly) : IServiceSource
{
    private IEnumerable<IServiceDescriptor> m_CachedDescriptors;

    /// <summary>
    /// Resolves service descriptors from the assembly by finding all concrete types implementing <see cref="IServiceDescriptor"/>
    /// with parameterless constructors.
    /// </summary>
    /// <returns>An enumerable collection of created service descriptors.</returns>
    public IEnumerable<IServiceDescriptor> Resolve() => m_CachedDescriptors ??= assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IServiceDescriptor).IsAssignableFrom(t) && t.GetConstructors().Any(c => c.GetParameters().Length is 0)).Select(Activator.CreateInstance).Cast<IServiceDescriptor>();
}