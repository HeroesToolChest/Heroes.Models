using System;
using System.ComponentModel;

namespace Heroes.Models.AbilityTalents;

/// <summary>
/// Specifices the tier of an ability.
/// </summary>
[Flags]
public enum AbilityTiers
{
    /// <summary>
    /// Indicates an unknown tier.
    /// </summary>
    [Description("Unknown Ability")]
    Unknown = 0,

    /// <summary>
    /// Indicates a basic tier.
    /// </summary>
    [Description("Basic Ability")]
    Basic = 1 << 0,

    /// <summary>
    /// Indicates a heroic tier.
    /// </summary>
    [Description("Heroic Ability")]
    Heroic = 1 << 1,

    /// <summary>
    /// Indicates a trait tier.
    /// </summary>
    [Description("Trait Ability")]
    Trait = 1 << 2,

    /// <summary>
    /// Indicates a mount tier.
    /// </summary>
    [Description("Mount Ability")]
    Mount = 1 << 3,

    /// <summary>
    /// Indicates an activable tier.
    /// </summary>
    [Description("Activable Ability")]
    Activable = 1 << 4,

    /// <summary>
    /// Indicates a hearth tier.
    /// </summary>
    [Description("Hearth Ability")]
    Hearth = 1 << 5,

    /// <summary>
    /// Indicates a taunt tier.
    /// </summary>
    [Description("Taunt Ability")]
    Taunt = 1 << 6,

    /// <summary>
    /// Indicates a dance tier.
    /// </summary>
    [Description("Dance Ability")]
    Dance = 1 << 7,

    /// <summary>
    /// Indicates a spray tier.
    /// </summary>
    [Description("Spray Ability")]
    Spray = 1 << 8,

    /// <summary>
    /// Indicates a voice tier.
    /// </summary>
    [Description("Voice Ability")]
    Voice = 1 << 9,

    /// <summary>
    /// Indicates a map mechanic tier.
    /// </summary>
    [Description("Map Mechanic Ability")]
    MapMechanic = 1 << 10,

    /// <summary>
    /// Indicates an interact tier.
    /// </summary>
    [Description("Interact Ability")]
    Interact = 1 << 11,

    /// <summary>
    /// Indicates an action tier.
    /// </summary>
    [Description("Action Ability")]
    Action = 1 << 12,

    /// <summary>
    /// Indicates a hidden tier.
    /// </summary>
    [Description("Hidden Ability")]
    Hidden = 1 << 13,

    /// <summary>
    /// Indicates a standard tier.
    /// </summary>
    Standard = Basic | Heroic | Trait | Mount | Activable,

    /// <summary>
    /// Indicates a special tier.
    /// </summary>
    Special = Hearth | Taunt | Dance | Spray | Voice | MapMechanic,

    /// <summary>
    /// Indicates a misc tier.
    /// </summary>
    Misc = Interact | Activable,
}
