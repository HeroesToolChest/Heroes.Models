namespace Heroes.Models;

/// <summary>
/// Contains the information for behavior veterancy data.
/// </summary>
public class BehaviorVeterancy : ExtractableBase<BehaviorVeterancy>, IExtractable, IMapSpecific
{
    /// <summary>
    /// Gets or sets a value indicating whether this is a combine modification type.
    /// </summary>
    public bool CombineModifications { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a combine xp type.
    /// </summary>
    public bool CombineXP { get; set; }

    /// <summary>
    /// Gets the collection of veterancy levels.
    /// </summary>
    public ICollection<VeterancyLevel> VeterancyLevels { get; } = new List<VeterancyLevel>();

    /// <summary>
    /// Gets a value indicating whether this is unique to a map.
    /// </summary>
    public bool IsMapUnique => !string.IsNullOrEmpty(MapName);

    /// <summary>
    /// Gets or sets the map name that is associated with this veterancy.
    /// </summary>
    public string? MapName { get; set; }
}
