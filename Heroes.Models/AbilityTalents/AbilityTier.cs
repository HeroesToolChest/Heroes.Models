using System;
using System.ComponentModel;

namespace Heroes.Models.AbilityTalents
{
    [Flags]
    public enum AbilityTier
    {
        [Description("Unknown Ability")]
        Unknown = 0,
        [Description("Basic Ability")]
        Basic = 1 << 0,
        [Description("Heroic Ability")]
        Heroic = 1 << 1,
        [Description("Trait Ability")]
        Trait = 1 << 2,
        [Description("Mount Ability")]
        Mount = 1 << 3,
        [Description("Activable Ability")]
        Activable = 1 << 4,
        [Description("Hearth Ability")]
        Hearth = 1 << 5,
        [Description("Taunt Ability")]
        Taunt = 1 << 6,
        [Description("Dance Ability")]
        Dance = 1 << 7,
        [Description("Spray Ability")]
        Spray = 1 << 8,
        [Description("Voice Ability")]
        Voice = 1 << 9,
        [Description("Map Mechanic Ability")]
        MapMechanic = 1 << 10,
        [Description("Interact Ability")]
        Interact = 1 << 11,
        [Description("Action Ability")]
        Action = 1 << 12,

        Standard = Basic | Heroic | Trait | Mount | Activable,
        Special = Hearth | Taunt | Dance | Spray | Voice | MapMechanic,
        Misc = Interact | Activable,
    }
}
