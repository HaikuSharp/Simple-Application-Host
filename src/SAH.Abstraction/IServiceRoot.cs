namespace SAH.Abstraction;

public interface IServiceRoot : IServiceSource
{
    IServiceRoot Append(IServiceSource source);
}
