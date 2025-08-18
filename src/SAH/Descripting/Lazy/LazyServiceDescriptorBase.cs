using SDI.Abstraction;

namespace SAH.Descripting.Lazy;

/// <summary>
/// Base class for lazy service descriptors that delay service instantiation until first access.
/// </summary>
/// <typeparam name="TService">The type of service being described.</typeparam>
public abstract class LazyServiceDescriptorBase<TService> : ServiceDescriptorBase<TService>
{
    /// <summary>
    /// Creates a service accessor for the specified service ID.
    /// </summary>
    /// <param name="id">The service ID.</param>
    /// <returns>The created service accessor.</returns>
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id) => CreateAccessor(id, GetServiceActivator());

    /// <summary>
    /// Gets the service instance activator.
    /// </summary>
    /// <returns>The service instance activator.</returns>
    protected abstract IServiceInstanceActivator GetServiceActivator();

    /// <summary>
    /// Creates a service accessor with the specified ID and activator.
    /// </summary>
    /// <param name="id">The service ID.</param>
    /// <param name="activator">The service instance activator.</param>
    /// <returns>The created service accessor.</returns>
    protected abstract IServiceAccessor CreateAccessor(ServiceId id, IServiceInstanceActivator activator);
}