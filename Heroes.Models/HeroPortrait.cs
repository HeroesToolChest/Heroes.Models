namespace Heroes.Models;

/// <summary>
/// Contains the properties for hero portraits.
/// </summary>
public class HeroPortrait
{
    /// <summary>
    /// Gets or sets the hero select portrait file name.
    /// </summary>
    public string? HeroSelectPortraitFileName { get; set; }

    /// <summary>
    /// Gets or sets the score screen portrait file name.
    /// </summary>
    public string? LeaderboardPortraitFileName { get; set; }

    /// <summary>
    /// Gets or sets the loading screen portrait file name.
    /// </summary>
    public string? LoadingScreenPortraitFileName { get; set; }

    /// <summary>
    /// Gets or sets the part panel portrait file name.
    /// </summary>
    public string? PartyPanelPortraitFileName { get; set; }

    /// <summary>
    /// Gets or sets the target portrait file name.
    /// </summary>
    public string? TargetPortraitFileName { get; set; }

    /// <summary>
    /// Gets or sets the draft screen file name.
    /// </summary>
    public string? DraftScreenFileName { get; set; }

    /// <summary>
    /// Gets the party frame file name.
    /// </summary>
    public ICollection<string> PartyFrameFileName { get; } = new List<string>();
}
