using SDI.Abstraction;
using SDI.Extensions;
using System;

namespace SAH.Descripting;

/// <summary>
/// Base class for service descriptors.
/// </summary>
/// <typeparam name="TService">The type of service being described.</typeparam>
public abstract class ServiceDescriptorBase<TService> : IServiceDescriptor
{
    /// <inheritdoc/>
    public Type ServiceType => typeof(TService);

    /// <inheritdoc/>
    public virtual object Key => "default";

    /// <inheritdoc/>
    public IServiceAccessor CreateAccessor() => CreateAccessor(this.GetId());

    /// <summary>
    /// Creates a service accessor for the specified service ID.
    /// </summary>
    /// <param name="id">The service ID.</param>
    /// <returns>The created service accessor.</returns>
    protected abstract IServiceAccessor CreateAccessor(ServiceId id);
}