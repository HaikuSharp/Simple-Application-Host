using SDI.Abstraction;
using SDI.Accessing.Lazy.Scoping;

namespace SAH.Descripting.Lazy;

public abstract class LazySingletonServiceDescriptorBase<TService> : LazyServiceDescriptorBase<TService>
{
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id, IServiceInstanceActivator activator) => new LazySingletonServiceAccessor(id, activator);
}
