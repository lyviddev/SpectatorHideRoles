using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using PlayerRoles;

namespace SpectatorHideRoles;

public class EventsHandler : CustomEventsHandler {
   public override void OnPlayerChangingRole(PlayerChangingRoleEventArgs ev) {
      bool hideSpectate = false;
      if (Plugin.Singleton.Config is null) return;


      if (Plugin.Singleton.Config.HideSCPSpectate) {
         if (ev.NewRole == RoleTypeId.Scp049) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp079) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp096) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp106) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp173) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp0492) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp939) {hideSpectate = true;}
         if (ev.NewRole == RoleTypeId.Scp3114) {hideSpectate = true;}
      }

      if (Plugin.Singleton.Config.HideTutorialSpectate) {
         if (ev.NewRole == RoleTypeId.Tutorial) {hideSpectate = true;}
      }

      ev.Player.IsSpectatable = hideSpectate;
   }
}