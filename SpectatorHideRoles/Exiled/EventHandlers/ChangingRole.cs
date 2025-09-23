using System;
using System.Linq;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace SpectatorHideRoles.EventHandlers;

public static class ChangingRole {
    public static void OnSpawned(SpawnedEventArgs ev) {
        bool showSpectate = true;
        foreach (var roleName in Plugin.Singleton.Config.HideRoles) {
            showSpectate = true;
            if (ev.Player.Role == roleName) 
                showSpectate = false;
            else if (!Plugin.Singleton.Config.HideCustomRoles.IsEmpty() && ev.Player.HasAnyCustomRole())
                foreach (var customRole in Plugin.Singleton.Config.HideCustomRoles.Where(customRole => CustomRole.TryGet(customRole, out var _)))
                    showSpectate = false;
        }
        ev.Player.IsSpectatable = showSpectate;
    }
}