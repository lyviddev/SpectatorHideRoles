using Exiled.API.Interfaces;
namespace SpectatorHideRoles;

public sealed class Config : IConfig
{
    public bool Debug { get; set; } = false;
    public bool IsEnabled { get; set; } = true;
    
    public bool HideScp  { get; set; } = true;
    public bool HideTutorial { get; set; } = false;
}