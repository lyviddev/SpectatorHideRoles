using System;
using System.Collections.Generic;
using Exiled.CustomRoles;
using Exiled.Loader;

namespace SpectatorHideRoles;
using Exiled.API.Features;
using player = Exiled.Events.Handlers.Player;
using customRoles = Exiled.CustomRoles.Events;

public class Plugin : Plugin<Config> {
    public override string Name => "SpectatorHideRolesExiled";
    public override string Author => "Lyvid_Dev";
    public override Version RequiredExiledVersion => new(9, 9, 2);
    public override Version Version => new(1, 1, 1);

    // public override string Prefix { get; } => "Some Random Thing";


    public static Plugin Singleton;

    public List<string> TempHideRoles = new() { };
    public List<string> TempHideCustomRoles = new() { "Serpents Hand Guardian" };

    public override void OnEnabled() {
        Singleton = this;
        player.Spawned += EventHandlers.ChangingRole.OnSpawned;
        base.OnEnabled(); 
    }

    public override void OnDisabled() {
        Singleton = null;
        player.Spawned -= EventHandlers.ChangingRole.OnSpawned;
        base.OnDisabled();
    }
}