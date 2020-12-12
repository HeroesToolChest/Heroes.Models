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
        /// Gets or sets the info text.
        /// </summary>
        public TooltipDescription? InfoText { get; set; }

        /// <summary>
        /// Gets or sets the search text. Space delimited.
        /// </summary>
        public string? SearchText { get; set; }

        /// <summary>
        /// Gets or sets the attribute id.
        /// </summary>
        public string? AttributeId { get; set; }

        /// <summary>
        /// Gets or sets the release date of the skin.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; } = Rarity.Common;

        /// <summary>
        /// Gets a unique collection of features.
        /// </summary>
        public HashSet<string> Features { get; } = new HashSet<string>();

        /// <summary>
        /// Gets a unique collection of <see cref="HeroSkin"/> ids. This are usually just texture variations of the same model.
        /// </summary>
        public HashSet<string> VariationSkinIds { get; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the franchise the hero skin belongs to.
        /// </summary>
        public HeroFranchise Franchise { get; set; }
    }
}
