using System;
using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using LabApi.Loader.Features.Plugins.Enums;

namespace SpectatorHideRoles;

public class Plugin : Plugin<config> {
    public static Plugin Singleton { get; set; } = null!;

    // Plugin Information
    public override string Name { get;  } = "SpectatorHideRolesExiled";
    public override string Author { get; } = "Lyvid_Dev";
    public override string Description { get; } = "Will hide the SCP roles and Tutorial roles from being able to be viewed by Spectators";
    public override Version Version { get; } = new (1, 2, 0);
    public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);
    public override LoadPriority Priority { get; } = LoadPriority.Low;

    public EventsHandler Events { get; } = new();

    public override void Enable() {
        Singleton = this;
        CustomHandlersManager.RegisterEventsHandler(Events);
    }

    public override void Disable() {
        Singleton = null!;
        CustomHandlersManager.UnregisterEventsHandler(Events);
    }
}