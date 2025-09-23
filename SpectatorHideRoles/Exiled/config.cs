using System.Collections.Generic;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace SpectatorHideRoles;

public sealed class Config : IConfig {
    public bool Debug { get; set; } = false;
    public bool IsEnabled { get; set; } = true;

    public bool SeparateCustomRoles { get; set; } = false;
    public string[] HideRoles { get; set; } = {"Tutorial"};

    public string[] HideCustomRoles { get; set; } = { };
}