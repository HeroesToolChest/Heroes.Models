using System.Collections.Generic;

namespace Heroes.Models
{
    public class Emoticon : ExtractableBase<Emoticon>, IExtractable
    {
        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or sets a collection of universal aliases for the emoticon.
        /// </summary>
        public ICollection<string> UniversalAliases { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets a collection of localized aliases for the emoticon.
        /// </summary>
        public ICollection<string> LocalizedAliases { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets a collection of search texts for the emoticon.
        /// </summary>
        public ICollection<string> SearchTexts { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets if the aliases are case sensitive.
        /// </summary>
        public bool IsAliasCaseSensitive { get; set; }

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
    }
}
