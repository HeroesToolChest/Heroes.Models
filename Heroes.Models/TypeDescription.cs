namespace Heroes.Models;

/// <summary>
/// Contains the information for type description data.
/// </summary>
public class TypeDescription : ExtractableBase<Boost>, IExtractable
{
    /// <summary>
    /// Gets or sets the texture sheet associated with the type description.
    /// </summary>
    public TextureSheet TextureSheet { get; set; } = new();

    /// <summary>
    /// Gets or sets the icon slot number on the <see cref="TextureSheet"/>. Zero index based.
    /// </summary>
    public int IconSlot { get; set; }

    /// <summary>
    /// Gets or sets the image file name.
    /// </summary>
    public string? ImageFileName { get; set; }
}
