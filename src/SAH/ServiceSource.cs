using SAH.Abstraction;
using SDI.Abstraction;
using System.Collections.Generic;

namespace SAH;

/// <inheritdoc cref="IServiceSource"/>
public sealed class ServiceSource(IEnumerable<IServiceDescriptor> descriptors) : IServiceSource
{
    /// <inheritdoc/>
    public IEnumerable<IServiceDescriptor> Resolve() => descriptors;
}