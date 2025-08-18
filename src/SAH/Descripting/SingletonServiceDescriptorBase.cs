using SDI.Abstraction;
using SDI.Accessing;

namespace SAH.Descripting;

/// <summary>
/// Base class for singleton service descriptors.
/// </summary>
/// <typeparam name="TService">The service interface type.</typeparam>
/// <typeparam name="TImplementation">The service implementation type.</typeparam>
public abstract class SingletonServiceDescriptorBase<TService, TImplementation> : ServiceDescriptorBase<TService>
{
    /// <inheritdoc/>
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id) => new SingletonServiceAccessor(id, GetServiceInstance());

    /// <summary>
    /// Gets the singleton service instance.
    /// </summary>
    /// <returns>The service instance.</returns>
    protected abstract TImplementation GetServiceInstance();
}