using System;

namespace Heroes.Models
{
    public class Banner : ExtractableBase<Banner>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the hero banners.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the attribute id.
        /// </summary>
        public string AttributeId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the release date of the banner.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string? CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this banner.
        /// </summary>
        public string? EventName { get; set; }
    }
}
