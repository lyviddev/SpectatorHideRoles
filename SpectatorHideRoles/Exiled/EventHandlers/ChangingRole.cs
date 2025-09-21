using System;
using System.Linq;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SpectatorHideRoles.EventHandlers;

public static class ChangingRole {
    public static void OnChangingRole(ChangingRoleEventArgs ev) {
        bool showSpectate = true;

        foreach (var roleName in Plugin.Singleton.Config.HideRoles) {
            if (Enum.TryParse<RoleTypeId>(roleName, out var roleType))
            {
                if (ev.NewRole == roleType) {showSpectate = false;}
            }
        }

        ev.Player.IsSpectatable = showSpectate;
    }
}