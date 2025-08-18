using SAH.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace SAH;

/// <inheritdoc cref="IServiceBuilder"/>
public sealed class ServiceBuilder : IServiceBuilder
{
    private readonly List<IServiceSource> m_Sources = [];

    /// <inheritdoc/>
    public IServiceBuilder Append(IServiceSource source)
    {
        m_Sources.Add(source);
        return this;
    }

    /// <inheritdoc/>
    public IServiceSource Build() => new ServiceSource(m_Sources.SelectMany(s => s.Resolve()));
}