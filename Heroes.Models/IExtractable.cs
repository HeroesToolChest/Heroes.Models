namespace Heroes.Models
{
    public interface IExtractable
    {
        /// <summary>
        /// Gets or sets the unqiue id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink id.
        /// </summary>
        string HyperlinkId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        string Name { get; set; }
    }
}
