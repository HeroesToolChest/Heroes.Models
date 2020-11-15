namespace Heroes.Models
{
    /// <summary>
    /// Provides basic properties that are used across all extractable model types from the game data.
    /// </summary>
    public interface IExtractable
    {
        /// <summary>
        /// Gets or sets the unique id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink id.
        /// </summary>
        string? HyperlinkId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        string? Name { get; set; }
    }
}
