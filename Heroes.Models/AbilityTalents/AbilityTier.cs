using System;
using System.ComponentModel;

namespace Heroes.Models.AbilityTalents
{
    [Flags]
    public enum AbilityTier
    {
        [Description("Basic Ability")]
        Basic,
        [Description("Heroic Ability")]
        Heroic,
        [Description("Trait Ability")]
        Trait,
        [Description("Mount Ability")]
        Mount,
        [Description("Activable Ability")]
        Activable,
        [Description("Hearth Ability")]
        Hearth,
        [Description("Taunt Ability")]
        Taunt,
        [Description("Dance Ability")]
        Dance,
        [Description("Spray Ability")]
        Spray,
        [Description("Voice Ability")]
        Voice,
        [Description("Map Mechanic Ability")]
        MapMechanic,
    }
}
