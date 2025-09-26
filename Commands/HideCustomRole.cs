using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;

namespace SpectatorHideRoles.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
internal class HideCustomRole : ICommand {
    public string Command { get; set; } = "hidecustomroles";
    public string Description { get; set; } = "Will hide the roles for every match";
    public string[] Aliases { get; set; } = { };

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        Log.Debug($"'hidecustomroles' command executed by '{sender.LogName}'");
        
        if (!sender.CheckPermission(PlayerPermissions.Vanish)) {
            Log.Debug("Invalid Permissions");
            response = "You do not have permission to use this command.";
            return false;
        }

        if (!arguments.IsEmpty()) {
            if (UInt32.TryParse(arguments.FirstElement(), out var customRoleId)) {
                if (CustomRole.TryGet(customRoleId, out var customRole)) {
                    Log.Debug(CustomRole.Get(customRoleId));

                    if (Plugin.Singleton.Config.HideCustomRoles == null) {
                        Plugin.Singleton.Config.HideCustomRoles = new() {customRole.Name};
                        response = $"Successfully hidden role '{customRole.Name}'";
                        return true;
                    }

                    foreach (var hiddenRoles in Plugin.Singleton.Config.HideCustomRoles) {
                        if (hiddenRoles == customRole.Name) {
                            Log.Debug($"Role '{customRole.Name}' is already hidden");
                            response = $"Role '{customRole.Name}' is already hidden";
                            return false;
                        }
                    }

                    // If it did not find the role hidden
                    Plugin.Singleton.Config.HideCustomRoles.Add(customRole.Name);
                    Log.Debug($"Successfully hidden role '{customRole.Name}'");
                    response = $"Successfully hidden role '{customRole.Name}'";
                    return true;
                }
            }
            // If it could not find the role
            Log.Debug($"Could not find Custom Role Id '{arguments.FirstElement()}'");
            response = $"Could not find Custom Role Id '{arguments.FirstElement()}'";
            return false;
        }
        // If there are no args found
        Log.Debug("No arguments provided");
        response = "Command Args for 'hidecustomroles':\n CustomRoleId";
        return true;
    }
}