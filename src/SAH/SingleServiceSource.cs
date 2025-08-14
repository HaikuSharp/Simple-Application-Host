using SAH.Abstraction;
using SDI.Abstraction;
using System.Collections.Generic;

namespace SAH;

public sealed class SingleServiceSource(IServiceDescriptor descriptor) : IServiceSource
{
    public IEnumerable<IServiceDescriptor> Resolve()
    {
        yield return descriptor;
    }
}