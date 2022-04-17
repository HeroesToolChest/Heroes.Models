namespace Heroes.Models;

/// <summary>
/// Provides the properties that are associated with map specific models.
/// </summary>
public interface IMapSpecific
{
    /// <summary>
    /// Gets a value indicating whether this object is unique to a map.
    /// </summary>
    bool IsMapUnique { get; }

    /// <summary>
    /// Gets or sets the map name that is associated this object.
    /// </summary>
    string? MapName { get; set; }
}
