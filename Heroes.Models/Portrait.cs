namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for portrait data.
    /// </summary>
    public class Portrait : ExtractableBase<Portrait>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the portrait.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this portrait.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string? CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the image file name.
        /// </summary>
        public string ImageFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the icon slot number.
        /// </summary>
        public int IconSlot { get; set; } = 0;
    }
}
