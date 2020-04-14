using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for emoticon pack data.
    /// </summary>
    public class EmoticonPack : ExtractableBase<EmoticonPack>, IExtractable
    {
        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the sort name used for sorting the emoticon packs.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string? CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this emoticon pack.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; } = Rarity.Common;

        /// <summary>
        /// Gets a unique collection of emoticons ids in this emoticon pack.
        /// </summary>
        public HashSet<string> EmoticonIds { get; } = new HashSet<string>();
    }
}
