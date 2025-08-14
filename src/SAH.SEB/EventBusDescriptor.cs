using SAH.Descripting.Lazy;
using SDI.Abstraction;
using SEB;
using SEB.Abstraction;

namespace SAH.SEB;

public sealed class EventBusDescriptor : LazySingletonServiceDescriptorBase<IEventBus>
{
    protected override IServiceInstanceActivator GetServiceActivator() => new EventBusActivator();

    private class EventBusActivator : IServiceInstanceActivator
    {
        public object Activate(ServiceId requestedId, IServiceProvider provider) => new EventBus();
    }
}
