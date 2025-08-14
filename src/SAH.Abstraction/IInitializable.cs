using System;

namespace SAH.Abstraction;

public interface IInitializable : IDisposable
{
    bool IsInitialized { get; }

    void Initialize();

    void Deinitialize();
}
