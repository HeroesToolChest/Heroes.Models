using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for hero skin data.
    /// </summary>
    public class HeroSkin : ExtractableBase<HeroSkin>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the hero skins.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the search text. Space delimited.
        /// </summary>
        public string? SearchText { get; set; }

        /// <summary>
        /// Gets or sets the attribute id.
        /// </summary>
        public string AttributeId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the release date of the skin.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; }

        /// <summary>
        /// Gets a unique collection of features.
        /// </summary>
        public HashSet<string> Features { get; } = new HashSet<string>();
    }
}
