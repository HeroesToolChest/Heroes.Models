using System;

namespace Heroes.Models
{
    public class Spray : ExtractableBase<Spray>, IExtractable
    {
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
        /// Gets or sets the release date.
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
        /// Gets or sets the event name associated with this spray.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the image file name.
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the animation count.
        /// </summary>
        public int AnimationCount { get; set; }

        /// <summary>
        /// Gets or sets the animation duration.
        /// </summary>
        public int AnimationDuration { get; set; }
    }
}
