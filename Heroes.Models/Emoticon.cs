using System.Collections.Generic;

namespace Heroes.Models;

/// <summary>
/// Contains the information for emoticon data.
/// </summary>
public class Emoticon : ExtractableBase<Emoticon>, IExtractable
{
    /// <summary>
    /// Gets or sets the description text.
    /// </summary>
    public TooltipDescription? Description { get; set; }

    /// <summary>
    /// Gets or sets the description locked text.
    /// </summary>
    public TooltipDescription? DescriptionLocked { get; set; }

    /// <summary>
    /// Gets a unique collection of universal aliases for the emoticon.
    /// </summary>
    public HashSet<string> UniversalAliases { get; } = new HashSet<string>();

    /// <summary>
    /// Gets a unique collection of localized aliases for the emoticon.
    /// </summary>
    public HashSet<string> LocalizedAliases { get; } = new HashSet<string>();

    /// <summary>
    /// Gets a unique collection of search texts for the emoticon.
    /// </summary>
    public HashSet<string> SearchTexts { get; } = new HashSet<string>();

    /// <summary>
    /// Gets or sets a value indicating whether the aliases are case sensitive.
    /// </summary>
    public bool IsAliasCaseSensitive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the emoticon is hidden.
    /// </summary>
    public bool IsHidden { get; set; }

    /// <summary>
    /// Gets or sets the hero id associated with the emoticon.
    /// </summary>
    public string? HeroId { get; set; }

    /// <summary>
    /// Gets or sets the hero skin id assoicated with the emoticon.
    /// </summary>
    public string? HeroSkinId { get; set; }

    /// <summary>
    /// Gets or sets the texture sheet associated with the emoticon.
    /// </summary>
    public TextureSheet TextureSheet { get; set; } = new TextureSheet();

    /// <summary>
    /// Gets or sets the image properties of the emoticon.
    /// </summary>
    public EmoticonImage Image { get; set; } = new EmoticonImage();
}
