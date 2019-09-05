namespace Heroes.Models
{
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
    }
}
