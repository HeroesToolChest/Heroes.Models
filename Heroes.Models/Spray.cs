using System;

namespace Heroes.Models
{
    public class Spray : IExtractable
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
        /// Gets or sets the sort name used for sorting the hero banners.
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the search text. Space delimited.
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Gets or sets the attribute id.
        /// </summary>
        public string AttributeId { get; set; }

        /// <summary>
        /// Gets or sets the release date of the banner.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; }
    }
}
