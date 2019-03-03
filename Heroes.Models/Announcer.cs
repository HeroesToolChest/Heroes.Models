﻿using System;

namespace Heroes.Models
{
    public class Announcer : IExtractable
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
        /// Gets or sets the sort name used for sorting the announcers.
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the attribute id.
        /// </summary>
        public string AttributeId { get; set; }

        /// <summary>
        /// Gets or sets the release date of the announcer.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the image file name.
        /// </summary>
        public string ImageFileName { get; set; }
    }
}