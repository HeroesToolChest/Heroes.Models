using System;

namespace Heroes.Models.AbilityTalents
{
    [Flags]
    public enum AbilityType
    {
        Unknown = 0,
        Q = 1 << 0,
        W = 1 << 1,
        E = 1 << 2,
        Heroic = 1 << 3,
        Z = 1 << 4,
        Trait = 1 << 5,
        Active = 1 << 6,
        Passive = 1 << 7,
        B = 1 << 8,
        Attack = 1 << 9,
        Stop = 1 << 10,
        Hold = 1 << 11,
        Cancel = 1 << 12,
        Interact = 1 << 13,
        Taunt = 1 << 14,
        Dance = 1 << 15,
        Spray = 1 << 16,
        Voice = 1 << 17,
        ForceMove = 1 << 18,

        Standard = Q | W | E | Heroic | Z | Trait | Active | Passive | B,
        Misc = Attack | Stop | Stop | Hold | Cancel | Interact | Taunt | Dance | Spray | Voice | ForceMove,
    }
}
