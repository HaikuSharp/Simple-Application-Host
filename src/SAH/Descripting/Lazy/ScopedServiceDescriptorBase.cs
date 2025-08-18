using SDI.Abstraction;
using SDI.Accessing.Lazy.Scoping;

namespace SAH.Descripting.Lazy;

/// <summary>
/// Base class for scoped service descriptors.
/// </summary>
/// <typeparam name="TService">The type of service being described.</typeparam>
public abstract class ScopedServiceDescriptorBase<TService> : LazyServiceDescriptorBase<TService>
{
    /// <inheritdoc/>
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id, IServiceInstanceActivator activator) => new ScopedServiceAccessor(id, activator);
}