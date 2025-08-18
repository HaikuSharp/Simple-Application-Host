using SAH.Abstraction;
using System;

namespace SAH.Exceptions;

/// <summary>
/// Exception thrown when attempting to initialize an already initialized object.
/// </summary>
public class AlreadyInitializedException(Type type) : Exception($"{type.FullName} already initialized.")
{
    /// <summary>
    /// Throws an AlreadyInitializedException if the object is already initialized.
    /// </summary>
    /// <param name="initializable">The object to check.</param>
    public static void ThrowIfIsIntitialized(IInitializable initializable)
    {
        if(!initializable.IsInitialized) return;
        throw new AlreadyInitializedException(initializable.GetType());
    }
}