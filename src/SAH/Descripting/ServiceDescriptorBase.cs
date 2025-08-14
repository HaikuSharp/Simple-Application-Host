using SDI.Abstraction;
using SDI.Extensions;
using System;

namespace SAH.Descripting;

public abstract class ServiceDescriptorBase<TService> : IServiceDescriptor
{
    public Type ServiceType => typeof(TService);

    public virtual object Key => "default";

    public IServiceAccessor CreateAccessor() => CreateAccessor(this.GetId());

    protected abstract IServiceAccessor CreateAccessor(ServiceId id);
}
