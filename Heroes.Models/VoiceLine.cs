using System;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for voice line data.
    /// </summary>
    public class VoiceLine : ExtractableBase<VoiceLine>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the voice lines.
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
        /// Gets or sets the release date.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the image file name.
        /// </summary>
        public string ImageFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hero id associated with the voiceline.
        /// </summary>
        public string HeroId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; } = Rarity.Common;
    }
}
