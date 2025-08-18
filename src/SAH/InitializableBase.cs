using SAH.Abstraction;
using SAH.Exceptions;
using System;

namespace SAH;

/// <summary>
/// Base class for initializable objects.
/// </summary>
public abstract class InitializableBase : IInitializable
{
    /// <inheritdoc/>
    public bool IsInitialized { get; private set; }

    /// <inheritdoc/>
    public void Initialize()
    {
        AlreadyInitializedException.ThrowIfIsIntitialized(this);
        OnInitialized();
        IsInitialized = true;
    }

    /// <inheritdoc/>
    public void Deinitialize()
    {
        NotInitializedException.ThrowIfIsNotIntitialized(this);
        IsInitialized = false;
        OnDeinitialize();
    }

    /// <summary>
    /// Called when the object is being initialized.
    /// </summary>
    protected abstract void OnInitialized();

    /// <summary>
    /// Called when the object is being deinitialized.
    /// </summary>
    protected abstract void OnDeinitialize();

    /// <inheritdoc/>
    public void Dispose()
    {
        if(IsInitialized) Deinitialize();
        GC.SuppressFinalize(this);
    }
}