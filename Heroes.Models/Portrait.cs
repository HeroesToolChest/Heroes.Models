namespace Heroes.Models
{
    public class Portrait : IExtractable
    {
        /// <summary>
        /// Gets or sets the unique id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink id.
        /// </summary>
        public string HyperlinkId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sort name used for sorting the portrait.
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this portrait.
        /// </summary>
        public string EventName { get; set; }
    }
}
