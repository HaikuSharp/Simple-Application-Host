using SAH.Abstraction;
using SDI.Abstraction;
using System.Collections.Generic;

namespace SAH;

/// <inheritdoc cref="IServiceSource"/>
public sealed class SingleServiceSource(IServiceDescriptor descriptor) : IServiceSource
{
    /// <inheritdoc/>
    public IEnumerable<IServiceDescriptor> Resolve()
    {
        yield return descriptor;
    }
}