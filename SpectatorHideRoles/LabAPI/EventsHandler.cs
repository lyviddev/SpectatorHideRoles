using System;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using PlayerRoles;

namespace SpectatorHideRoles;

public class EventsHandler : CustomEventsHandler {
   public override void OnPlayerChangingRole(PlayerChangingRoleEventArgs ev) {
      bool hideSpectate = false;
      if (Plugin.Singleton.Config is null) return;

      foreach (var roleName in Plugin.Singleton.Config.HideRoles) {
         if (Enum.TryParse<RoleTypeId>(roleName, out var roleType)) {
            if (ev.NewRole == roleType) {hideSpectate = true;}
         }
      }

      ev.Player.IsSpectatable = hideSpectate;
   }
}