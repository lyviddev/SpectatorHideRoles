using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;

namespace SpectatorHideRoles.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
internal class ShowCustomRole : ICommand {
    public string Command { get; set; } = "showcustomroles";
    public string Description { get; set; } = "Will show the roles for every match";
    public string[] Aliases { get; set; } = { };

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        Log.Debug($"'showcustomroles' command executed by '{sender.LogName}'");
        
        if (!sender.CheckPermission(PlayerPermissions.Vanish)) {
            Log.Debug("Invalid Permissions\n");
            response = "You do not have permission to use this command.";
            return false;
        }

        if (!arguments.IsEmpty()) {
            if (UInt32.TryParse(arguments.FirstElement(), out var customRoleId)) {
                if (CustomRole.TryGet(customRoleId, out var customRole)) {
                    if (Plugin.Singleton.Config.HideRoles == null) {
                        Log.Debug($"Role '{customRole.Name}' is not hidden'");
                        response = $"Role '{customRole.Name}' is not hidden";
                        return false;
                    }

                    foreach (var hiddenRoles in Plugin.Singleton.Config.HideCustomRoles) {
                        if (hiddenRoles == customRole.Name) {
                            Plugin.Singleton.Config.HideCustomRoles.Remove(customRole.Name);
                            Log.Debug($"Successfully shown role '{customRole.Name}'");
                            response = $"Successfully shown role '{customRole.Name}'";
                            return true;
                        }
                    }

                    // If the role is shown
                    Log.Debug($"Role '{customRole.Name}' is not hidden'");
                    response = $"Role '{customRole.Name}' is not hidden";
                    return false;
                }
            }
            // If it could not find the role
            Log.Debug($"Could not find Custom Role Id '{arguments.FirstElement()}'");
            response = $"Could not find Custom Role Id '{arguments.FirstElement()}'";
            return false;
        }
        // If there are no args found
        Log.Debug("No arguments provided");
        response = "Command Args for 'showcustomroles':\n RoleName";
        return true;
    }
}