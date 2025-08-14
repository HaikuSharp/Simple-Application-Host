using SDI.Abstraction;
using SDI.Accessing.Lazy;

namespace SAH.Descripting.Lazy;

public abstract class TransientServiceDescriptorBase<TService> : LazyServiceDescriptorBase<TService>
{
    protected sealed override IServiceAccessor CreateAccessor(ServiceId id, IServiceInstanceActivator activator) => new TransientServiceAccessor(id, activator);
}
