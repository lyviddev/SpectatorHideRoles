using System.Collections.Generic;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace SpectatorHideRoles;

public sealed class Config : IConfig {
    public bool Debug { get; set; } = false;
    public bool IsEnabled { get; set; } = true;
    public bool HideDuringRoleSwap { get; set; } = false;
    public List<RoleTypeId> HideRoles { get; set; } = new() {
        RoleTypeId.Tutorial,
    };

    public List<string> HideCustomRoles { get; set; } = new() {
        "Serpents Hand Guardian",
    };
}