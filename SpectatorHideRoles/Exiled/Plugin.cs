namespace SpectatorHideRoles;
using Exiled.API.Features;
using player = Exiled.Events.Handlers.Player;

public class Plugin : Plugin<Config>
{
    public static Plugin Instance;

    public override void OnEnabled() {
        Instance = this;
        player.ChangingRole += EventHandlers.ChangingRole.OnChangingRole;
        base.OnEnabled();
    }

    public override void OnDisabled() {
        Instance = null;
        player.ChangingRole -= EventHandlers.ChangingRole.OnChangingRole;
        base.OnDisabled();
    }
}