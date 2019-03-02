namespace Heroes.Models
{
    public interface IExtractable
    {
        /// <summary>
        /// Gets or sets the unqiue id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        string Name { get; set; }
    }
}
