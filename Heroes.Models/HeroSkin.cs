using System;

namespace Heroes.Models
{
    public class HeroSkin : IExtractable
    {
        /// Gets or sets the short name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sort name used for sorting the hero skins.
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the information text.
        /// </summary>
        public string InfoText { get; set; }

        /// <summary>
        /// Gets or sets the search text. Space delimited.
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Gets or sets the release date of the skin.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
    }
}
