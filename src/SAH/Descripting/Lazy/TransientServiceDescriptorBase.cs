using SDI.Abstraction;
using SDI.Accessing.Lazy;

namespace SAH.Descripting.Lazy;

/// <summary>
/// Base class for transient service descriptors.
/// </summary>
/// <typeparam name="TService">The type of service being described.</typeparam>
public abstract class TransientServiceDescriptorBase<TService> : LazyServiceDescriptorBase<TService>
{
    /// <inheritdoc/>
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id, IServiceInstanceActivator activator) => new TransientServiceAccessor(id, activator);
}