using System;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace SpectatorHideRoles.EventHandlers;

public static class ChangingRole {
    public static void OnChangingRole(ChangingRoleEventArgs ev) {
        bool showSpectate = true;

        Timing.CallDelayed(0.1f, () => {
            foreach (var roleName in Plugin.Singleton.Config.HideRoles) {
                if (Enum.TryParse<RoleTypeId>(roleName, out var roleType) && ev.NewRole == roleType) {
                    if (Plugin.Singleton.Config.SeparateCustomRoles && !ev.Player.HasAnyCustomRole() || !Plugin.Singleton.Config.SeparateCustomRoles) { showSpectate = false; }
                
                    else if (Plugin.Singleton.Config.SeparateCustomRoles && ev.Player.HasAnyCustomRole()) {
                        foreach (var customRoleName in Plugin.Singleton.Config.HideCustomRoles) {
                            if (CustomRole.TryGet(customRoleName, out _)) { showSpectate = false; }
                        }
                    }
                }
            }
            
            ev.Player.IsSpectatable = showSpectate;
        });
    }
}