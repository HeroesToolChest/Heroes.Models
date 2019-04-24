using System;

namespace Heroes.Models.AbilityTalents
{
    [Flags]
    public enum AbilityType
    {
        Q = 0,
        W = 1 << 0,
        E = 1 << 1,
        Heroic = 1 << 2,
        Z = 1 << 3,
        Trait = 1 << 4,
        Active = 1 << 5,
        Passive = 1 << 6,
        B = 1 << 7,
        Attack = 1 << 8,
        Stop = 1 << 9,
        Hold = 1 << 10,
        Cancel = 1 << 11,
        Interact = 1 << 12,
        Taunt = 1 << 13,
        Dance = 1 << 14,
        Spray = 1 << 15,
        Voice = 1 << 16,
        ForceMove = 1 << 17,

        Standard = Q | W | E | Heroic | Z | Trait | Active | Passive | B,
        Misc = Attack | Stop | Stop | Hold | Cancel | Interact | Taunt | Dance | Spray | Voice | ForceMove,
    }
}
