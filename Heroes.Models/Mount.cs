﻿using System;

namespace Heroes.Models
{
    public class Mount : ExtractableBase<Mount>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the mounts.
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
        /// Gets or sets the release date of the mount.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; }

        /// <summary>
        /// Gets or sets the type of mount category.
        /// </summary>
        public string? MountCategory { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string? CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this mount.
        /// </summary>
        public string? EventName { get; set; }
    }
}
