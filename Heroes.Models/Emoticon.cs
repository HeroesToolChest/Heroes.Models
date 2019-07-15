using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    public class Emoticon : ExtractableBase<Emoticon>, IExtractable
    {
        private readonly HashSet<string> UniversalAliasList = new HashSet<string>();
        private readonly HashSet<string> LocalizedAliasList = new HashSet<string>();
        private readonly HashSet<string> SearchTextList = new HashSet<string>();

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets a collection of universal aliases for the emoticon.
        /// </summary>
        public IEnumerable<string> UniversalAliases => UniversalAliasList;

        /// <summary>
        /// Gets a collection of localized aliases for the emoticon.
        /// </summary>
        public IEnumerable<string> LocalizedAliases => LocalizedAliasList;

        /// <summary>
        /// Gets a collection of search texts for the emoticon.
        /// </summary>
        public IEnumerable<string> SearchTexts => SearchTextList;

        /// <summary>
        /// Gets or sets if the aliases are case sensitive.
        /// </summary>
        public bool IsAliasCaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets if the emoticon is hidden.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets the hero id associated with the emoticon.
        /// </summary>
        public string HeroId { get; set; }

        /// <summary>
        /// Gets or sets the hero skin id assoicated with the emoticon.
        /// </summary>
        public string HeroSkinId { get; set; }

        /// <summary>
        /// Get or sets the texture sheet associated with the emoticon.
        /// </summary>
        public TextureSheet TextureSheet { get; set; } = new TextureSheet();

        /// <summary>
        /// Gets or sets the image properties of the emoticon.
        /// </summary>
        public EmoticonImage Image { get; set; } = new EmoticonImage();

        /// <summary>
        /// Adds a universal aliase value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddUniversalAlias(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            UniversalAliasList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsUniversalAlias(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return UniversalAliasList.Contains(value);
        }

        /// <summary>
        /// Adds a localized aliase value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddLocalizedAlias(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            LocalizedAliasList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsLocalizedAlias(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return LocalizedAliasList.Contains(value);
        }

        /// <summary>
        /// Adds a search text value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddSearchText(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            SearchTextList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsSearchText(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return SearchTextList.Contains(value);
        }
    }
}
