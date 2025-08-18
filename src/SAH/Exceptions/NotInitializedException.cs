using SAH.Abstraction;
using System;

namespace SAH.Exceptions;

/// <summary>
/// Exception thrown when attempting to use an uninitialized object.
/// </summary>
public class NotInitializedException(Type type) : Exception($"{type.FullName} is not initialized.")
{
    /// <summary>
    /// Throws a NotInitializedException if the object is not initialized.
    /// </summary>
    /// <param name="initializable">The object to check.</param>
    public static void ThrowIfIsNotIntitialized(IInitializable initializable)
    {
        if(initializable.IsInitialized) return;
        throw new NotInitializedException(initializable.GetType());
    }
}