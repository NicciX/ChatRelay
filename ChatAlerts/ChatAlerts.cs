using System.Reflection;
using ChatAlerts.Gui;
using Dalamud.Game.Command;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using XivCommon;
using Dalamud.Game;
using Dalamud.IoC;
using ChatAlerts.Ipc;


namespace ChatAlerts;

public class ChatAlerts : IDalamudPlugin
{
    public string Name
        => "Chat Alerts";

    private const string CommandName = "/chatalerts";

    private bool disposed = false;
    [PluginService] internal static ISigScanner Scanner { get; private set; } = null!;
    internal static XivCommonBase Common { get; private set; } = null!;
    internal static ServerChat ServerChat { get; private set; } = null!;

    //private readonly IPluginLog _pluginLog;


    public static    ChatAlertsConfig Config { get; private set; } = null!;
    private readonly Interface        _interface;
    public readonly  ChatWatcher      Watcher;
    private readonly ExternalPluginHandler _externalPluginHandler;

    public static string Version { get; private set; } = string.Empty;

    public ChatAlerts(IDalamudPluginInterface pluginInterface, IPluginLog _pluginLog)
    {
        //ECommonsMain.Init(pluginInterface, this);
        ServerChat = new(Scanner);
        Moon.Initialize(pluginInterface);
        Config  = ChatAlertsConfig.Load();
        Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "";
        Watcher = new ChatWatcher();
        _externalPluginHandler = new ExternalPluginHandler(pluginInterface, _pluginLog);
        _externalPluginHandler.RegisterFunctions();


        _interface = new Interface(this);

        Moon.Commands.AddHandler(CommandName, new CommandInfo(OnConfigCommandHandler)
        {
            HelpMessage = $"Open config window for {Name}",
            ShowInHelp  = true,
        });
    }

    public void OnConfigCommandHandler(object command, object args)
        => _interface.Visible = !_interface.Visible;

    

    public void Dispose()
    {
        _interface.Dispose();
        Watcher.Dispose();
        Config.Dispose();
        Moon.Commands.RemoveHandler(CommandName);
        disposed = true;
    }


}
