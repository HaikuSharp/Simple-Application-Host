namespace SAH;

/// <summary>
/// Defines the initialization order for services.
/// </summary>
public enum EServiceOrder
{
    /// <summary>
    /// Root services that should be initialized first.
    /// </summary>
    RootService = -10,

    /// <summary>
    /// Default initialization order.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Regular services.
    /// </summary>
    Service = 10,

    /// <summary>
    /// API services that should be initialized last.
    /// </summary>
    ApiService = 20
}