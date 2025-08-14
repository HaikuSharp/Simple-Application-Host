using SAH.Abstraction;
using SDI.Abstraction;
using System.Collections.Generic;

namespace SAH;

public sealed class ServiceSource(IEnumerable<IServiceDescriptor> descriptors) : IServiceSource
{
    public IEnumerable<IServiceDescriptor> Resolve() => descriptors;
}
