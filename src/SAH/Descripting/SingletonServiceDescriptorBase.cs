using SDI.Abstraction;
using SDI.Accessing;

namespace SAH.Descripting;

public abstract class SingletonServiceDescriptorBase<TService, TImplementation> : ServiceDescriptorBase<TService>
{
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id) => new SingletonServiceAccessor(id, GetServiceInstance());

    protected abstract TImplementation GetServiceInstance();
}
