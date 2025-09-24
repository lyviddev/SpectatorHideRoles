using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace SpectatorHideRoles.EventHandlers;

public static class ChangingRole {
    public static void OnSpawned(SpawnedEventArgs ev) {
        if (Plugin.Singleton.Config.HideDuringRoleSwap)
            ev.Player.IsSpectatable = false;
        

        Timing.CallDelayed(0.1f, () => {
            bool showSpectate = true;

            try {
                foreach (var roleName in Plugin.Singleton.Config.HideRoles)
                    if (ev.Player.Role == roleName && !ev.Player.HasAnyCustomRole()) {
                        showSpectate = false;
                        Log.Debug("Player does not have any custom roles.");
                        break;
                    }
            }
            catch {
                Log.Debug("This caused an error! Please contact the developer in the EXILED Discord Server!");
                Log.Debug("Error Location: RoleCheck");
                Log.Debug("Possible Issue: Config.HideRole is left as 'hide_roles: '");
            }
            
            // ----------
            if (Plugin.Singleton.Config.Debug)
                foreach (var plrCustomRole in ev.Player.GetCustomRoles()) {
                    Log.Debug(plrCustomRole);
                }
            // ----------
            

            try {
                if (ev.Player.HasAnyCustomRole() && !Plugin.Singleton.Config.HideCustomRoles.IsEmpty()) {
                    bool breakForLoop = false;
                    showSpectate = true;

                    Log.Debug("Player has custom roles!");
                    foreach (var customRoleName in Plugin.Singleton.Config.HideCustomRoles) {
                        Log.Debug($"Custom role: {customRoleName}");
                        foreach (var plrCustomRole in ev.Player.GetCustomRoles())
                            if (customRoleName == plrCustomRole.Name) {
                                showSpectate = false;
                                breakForLoop = true;
                                break;
                            }

                        if (breakForLoop)
                            break;
                    }
                }
            } catch {
                Log.Debug("This caused an error! Please contact the developer in the EXILED Discord Server!");
                Log.Debug("Error Location: CustomRoleCheck");
                Log.Debug("Possible Issue: Config.HideCustomRole is left as 'hide_custom_roles: '");
            }
            
            Log.Debug($"ShowSpectate: {showSpectate}");
            ev.Player.IsSpectatable = showSpectate;
        });
    }
}