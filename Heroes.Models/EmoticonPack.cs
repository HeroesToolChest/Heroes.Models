using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    public class EmoticonPack : ExtractableBase<EmoticonPack>, IExtractable
    {
        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the sort name used for sorting the emoticon packs.
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this emoticon pack.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the emoticons in this emoticon pack.
        /// </summary>
        public ICollection<string> EmoticonCollection { get; set; } = new List<string>();
    }
}
