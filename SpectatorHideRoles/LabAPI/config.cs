using System.Collections.Generic;
using PlayerRoles;

namespace SpectatorHideRoles
{
    public class config {
        public List<RoleTypeId> HideRoles { get; set; } = new() {
            RoleTypeId.Tutorial,
        };
    }
}