using SAH.Abstraction;
using System;

namespace SAH.Exceptions;

public class NotInitializedException(Type type) : Exception($"{type.FullName} is not initialized.")
{
    public static void ThrowIfIsNotIntitialized(IInitializable initializable)
    {
        if(initializable.IsInitialized) return;
        throw new NotInitializedException(initializable.GetType());
    }
}