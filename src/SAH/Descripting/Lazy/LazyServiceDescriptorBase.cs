using SDI.Abstraction;

namespace SAH.Descripting.Lazy;

public abstract class LazyServiceDescriptorBase<TService> : ServiceDescriptorBase<TService>
{
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id) => CreateAccessor(id, GetServiceActivator());

    protected abstract IServiceInstanceActivator GetServiceActivator();

    protected abstract IServiceAccessor CreateAccessor(ServiceId id, IServiceInstanceActivator activator);
}
