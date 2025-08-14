using SAH.Abstraction;
using SDI.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace SAH;

public sealed class ServiceRoot : IServiceRoot
{
    private readonly List<IServiceSource> m_Sources = [];

    public IServiceRoot Append(IServiceSource source)
    {
        m_Sources.Add(source);
        return this;
    }

    public IEnumerable<IServiceDescriptor> Resolve() => m_Sources.SelectMany(s => s.Resolve());
}
