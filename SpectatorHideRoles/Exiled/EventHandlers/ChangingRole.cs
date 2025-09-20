using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SpectatorHideRoles.EventHandlers;

public static class ChangingRole {
    public static void OnChangingRole(ChangingRoleEventArgs ev) {
        bool showSpectate = true;
        
        if (Plugin.Instance.Config.HideScp) {
            if (ev.NewRole == RoleTypeId.Scp049) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp079) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp079) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp096) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp106) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp173) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp0492) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp939) {showSpectate = false;}
            if (ev.NewRole == RoleTypeId.Scp3114) {showSpectate = false;}
        }

        if (Plugin.Instance.Config.HideTutorial) {
            if (ev.NewRole == RoleTypeId.Tutorial) {showSpectate = false;}
        }

        ev.Player.IsSpectatable = showSpectate;
    }
}