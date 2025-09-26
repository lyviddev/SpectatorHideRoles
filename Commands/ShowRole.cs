using System;
using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;

namespace SpectatorHideRoles.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
internal class ShowRole : ICommand {
    public string Command { get; set; } = "showroles";
    public string Description { get; set; } = "Will show the roles for every match";
    public string[] Aliases { get; set; } = { };

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        Log.Debug($"'showroles' command executed by '{sender.LogName}'");
        
        if (!sender.CheckPermission(PlayerPermissions.Vanish)) {
            Log.Debug("Invalid Permissions");
            response = "You do not have permission to use this command.";
            return false;
        }

        if (!arguments.IsEmpty()) {
            if (Enum.TryParse<RoleTypeId>(arguments.FirstElement(), out var roleType)) {
                if (Plugin.Singleton.Config.HideRoles == null) {
                    Log.Debug($"Role '{arguments.FirstElement()}' is not hidden'");
                    response = $"Role '{arguments.FirstElement()}' is not hidden";
                    return false;
                }
                
                foreach (var hiddenRoles in Plugin.Singleton.Config.HideRoles) {
                    if (hiddenRoles == roleType) {
                        Plugin.Singleton.Config.HideRoles.Remove(roleType);
                        Log.Debug($"Successfully shown role '{arguments.FirstElement()}'");
                        response = $"Successfully shown role '{arguments.FirstElement()}'";
                        return true;
                    }
                }
                
                // If the role is shown
                Log.Debug($"Role '{arguments.FirstElement()}' is not hidden'");
                response = $"Role '{arguments.FirstElement()}' is not hidden";
                return false;
            }
            // If it could not find the role
            Log.Debug($"Could not find role '{arguments.FirstElement()}'");
            response = $"Could not find role '{arguments.FirstElement()}'";
            return false;
        }
        // If there are no args found
        Log.Debug("No arguments provided");
        response = "Command Args for 'showroles':\n RoleName";
        return true;
    }
}