using Dalamud.Game;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.Gui.Dtr;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

using XivCommon;

namespace ChatAlerts;

internal class Service {
    [PluginService] public static IChatGui ChatGui { get; private set; } = null!;
    [PluginService] public static ISigScanner Scanner { get; private set; } = null!;
    [PluginService] public static IPluginLog Log { get; private set; } = null!;
    public static XivCommonBase Common { get; private set; } = null!;
	public static ServerChat ServerChat { get; private set; } = null!;

	public Service() {
		//Common = new(Interface);
		//ServerChat = Common.Functions.Chat;
		// XivCommon isn't updated yet, so we're ripping the chat functionality locally
		ServerChat = new(Scanner);
	}
}
