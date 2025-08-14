using SAH.Abstraction;
using SAH.Exceptions;
using System;

namespace SAH;

public abstract class InitializableBase : IInitializable
{
    public bool IsInitialized { get; private set; }

    public void Initialize()
    {
        AlreadyInitializedException.ThrowIfIsIntitialized(this);
        OnInitialized();
        IsInitialized = true;
    }

    public void Deinitialize()
    {
        NotInitializedException.ThrowIfIsNotIntitialized(this);
        IsInitialized = false;
        OnDeinitialize();
    }

    protected abstract void OnInitialized();

    protected abstract void OnDeinitialize();

    public void Dispose()
    {
        if(IsInitialized) Deinitialize();
        GC.SuppressFinalize(this);
    }
}
