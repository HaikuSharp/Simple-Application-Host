using SDI.Abstraction;
using System.Collections.Generic;

namespace SAH.Abstraction;

public interface IServiceSource
{
    IEnumerable<IServiceDescriptor> Resolve();
}
