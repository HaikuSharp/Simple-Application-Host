using SAH.Abstraction;

namespace SAH;

public abstract class ApplicationServiceBase : InitializableBase, IApplicationService
{
    public virtual string Name => GetType().Name;

    public virtual int Order => (int)EServiceOrder.Default;
}
