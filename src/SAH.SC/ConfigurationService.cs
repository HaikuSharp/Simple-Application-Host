using SAH.SC.Abstraction;
using SC;
using SC.Abstraction;
using SC.Extensions;
using Sugar.Object.Extensions;
using System.IO;
using System.Threading.Tasks;

namespace SAH.SC;

public sealed class ConfigurationService(IConfigurationFileResolver resolver, IConfigurationSettings settings) : ApplicationServiceBase, IConfigurationService
{
    private const string CONFUIGURATIONS_PATH = "Configurations";
    private const string ROOT_CONFIGURATION_NAME = "Root";

    public event ConfigurationRootSaveHandler OnRootSaved;
    public event ConfigurationRootLoadHandler OnRootLoaded;

    public IConfigurationRoot Root { get; private set; }

    public bool IsLoaded { get; private set; }

    public override int Order => (int)EServiceOrder.RootService;

    protected override void OnInitialized()
    {
        ConfigurationBuilder builder = new();

        if(!Directory.Exists(CONFUIGURATIONS_PATH))
        {
            Directory.CreateDirectory(CONFUIGURATIONS_PATH).Forget();
            return;
        }

        foreach(string filePath in Directory.GetFiles(CONFUIGURATIONS_PATH)) builder.Append(resolver.Resolve(filePath)).Forget();

        var root = Root = builder.Build(ROOT_CONFIGURATION_NAME, settings);

        Task.Run(LoadConfigurationAsync).Forget();
    }

    protected override void OnDeinitialize() => Task.Run(SaveConfigurationAsync).Forget();

    private async Task SaveConfigurationAsync()
    {
        var root = Root;

        if(root is not null)
        {
            await root.SaveAsync();
            OnRootSaved?.Invoke(root);
            Root = null;
        }

        IsLoaded = false;
    }

    private async Task LoadConfigurationAsync()
    {
        var root = Root;

        if(root is not null)
        {
            await root.LoadAsync();
            OnRootLoaded?.Invoke(root);
        }

        IsLoaded = true;
    }
}
