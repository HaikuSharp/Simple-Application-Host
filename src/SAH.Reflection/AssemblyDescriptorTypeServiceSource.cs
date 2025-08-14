using SAH.Abstraction;
using SDI.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SAH.Reflection;

public sealed class AssemblyDescriptorTypeServiceSource(Assembly assembly) : IServiceSource
{
    private IEnumerable<IServiceDescriptor> m_CachedDescriptors;

    public IEnumerable<IServiceDescriptor> Resolve() => m_CachedDescriptors ??= assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IServiceDescriptor).IsAssignableFrom(t) && t.GetConstructors().Any(c => c.GetParameters().Length is 0)).Select(Activator.CreateInstance).Cast<IServiceDescriptor>();
}
