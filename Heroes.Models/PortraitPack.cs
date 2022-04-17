using System.Collections.Generic;

namespace Heroes.Models;

/// <summary>
/// Contains the information for portrait data.
/// </summary>
public class PortraitPack : ExtractableBase<PortraitPack>, IExtractable
{
    /// <summary>
    /// Gets or sets the sort name used for sorting the portrait.
    /// </summary>
    public string? SortName { get; set; }

    /// <summary>
    /// Gets a unique collection of reward portrait ids in the portrait pack.
    /// </summary>
    public HashSet<string> RewardPortraitIds { get; } = new();

    /// <summary>
    /// Gets or sets the event name associated with this portrait.
    /// </summary>
    public string? EventName { get; set; }

    /// <summary>
    /// Gets or sets the rarity.
    /// </summary>
    public Rarity Rarity { get; set; } = Rarity.Common;
}
