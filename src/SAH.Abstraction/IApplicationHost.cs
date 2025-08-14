using SDI.Abstraction;
using IServiceProvider = SDI.Abstraction.IServiceProvider;

namespace SAH.Abstraction;

public interface IApplicationHost : IInitializable
{
    IServiceController Controller { get; }

    IServiceProvider RootScope { get; }

    void Load(IServiceSource source);

    void Unload(IServiceSource source);
}
