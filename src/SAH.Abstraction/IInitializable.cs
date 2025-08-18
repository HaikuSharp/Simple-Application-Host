using System;

namespace SAH.Abstraction;

/// <summary>
/// Represents an object that can be initialized and deinitialized.
/// </summary>
public interface IInitializable : IDisposable
{
    /// <summary>
    /// Gets a value indicating whether the object is initialized.
    /// </summary>
    bool IsInitialized { get; }

    /// <summary>
    /// Initializes the object.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Deinitializes the object.
    /// </summary>
    void Deinitialize();
}