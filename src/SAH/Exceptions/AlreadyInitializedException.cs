using SAH.Abstraction;
using System;

namespace SAH.Exceptions;

public class AlreadyInitializedException(Type type) : Exception($"{type.FullName} already initialized.")
{
    public static void ThrowIfIsIntitialized(IInitializable initializable)
    {
        if(!initializable.IsInitialized) return;
        throw new AlreadyInitializedException(initializable.GetType());
    }
}
