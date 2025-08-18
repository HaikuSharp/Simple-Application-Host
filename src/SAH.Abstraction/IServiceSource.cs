using SDI.Abstraction;
using System.Collections.Generic;

namespace SAH.Abstraction;

/// <summary>
/// Represents a source of service descriptors that can be resolved.
/// </summary>
public interface IServiceSource
{
    /// <summary>
    /// Resolves and returns a collection of service descriptors.
    /// </summary>
    /// <returns>An enumerable collection of service descriptors.</returns>
    IEnumerable<IServiceDescriptor> Resolve();
}