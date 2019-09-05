using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    public class HeroSkin : ExtractableBase<HeroSkin>, IExtractable
    {
        private readonly HashSet<string> FeaturesList = new HashSet<string>();

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
        /// Gets a collection of features.
        /// </summary>
        public IEnumerable<string> Features => FeaturesList;

        /// <summary>
        /// Adds a feature value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddFeature(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            FeaturesList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool FeatureExists(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return FeaturesList.Contains(value);
        }
    }
}
