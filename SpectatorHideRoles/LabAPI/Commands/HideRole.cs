using System;
using CommandSystem;
using PlayerRoles;

namespace SpectatorHideRoles.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
internal class HideRole : ICommand {
    public string Command { get; set; } = "hideroles";
    public string Description { get; set; } = "Will hide the roles for every match";
    public string[] Aliases { get; set; } = { };

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        DebugLog.Log($"'hideroles' command executed by '{sender.LogName}'");

        if (!sender.CheckPermission(PlayerPermissions.Vanish)) {
            DebugLog.Log("Invalid Permissions");
            response = "You do not have permission to use this command.";
            return false;
        }

        if (!arguments.IsEmpty()) {
            if (Enum.TryParse<RoleTypeId>(arguments.FirstElement(), out var roleType)) {
                if (Plugin.Singleton.Config.HideRoles == null) {
                    Plugin.Singleton.Config.HideRoles = new () {roleType};
                    DebugLog.Log($"Successfully hidden role '{roleType}'");
                    response = $"Successfully hidden role '{roleType}'";
                    return true;
                }
                
                foreach (var hiddenRoles in Plugin.Singleton.Config.HideRoles) {
                    if (hiddenRoles == roleType) {
                        DebugLog.Log($"Role '{roleType}' is already hidden");
                        response = $"Role '{roleType}' is already hidden";
                        return false;
                    }
                }
                // If it did not find the role hidden
                Plugin.Singleton.Config.HideRoles.Add(roleType);
                DebugLog.Log($"Successfully hidden role '{roleType}'");
                response = $"Successfully hidden role '{roleType}'";
                return true;
            }
            // If it could not find the role
            DebugLog.Log($"Could not find role '{arguments.FirstElement()}'");
            response = $"Could not find role '{arguments.FirstElement()}'";
            return false;
        }
        // If there are no args found
        DebugLog.Log("No arguments provided");
        response = "Command Args for 'hideroles':\n RoleName";
        return true;
    }
}