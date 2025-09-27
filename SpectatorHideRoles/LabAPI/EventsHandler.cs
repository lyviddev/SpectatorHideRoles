using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using PlayerRoles;

namespace SpectatorHideRoles;

public class EventsHandler : CustomEventsHandler {
   public override void OnPlayerChangingRole(PlayerChangingRoleEventArgs ev) {
      bool hideSpectate = false;
      
      if (Plugin.Singleton.Config is null) return;

      foreach (var role in Plugin.Singleton.Config.HideRoles) {
         if (ev.Player.Role == role) { hideSpectate = true; break; }
      }

      ev.Player.IsSpectatable = hideSpectate;
   }
}