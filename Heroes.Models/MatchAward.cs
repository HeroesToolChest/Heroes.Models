using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HeroesData")]
[assembly: InternalsVisibleTo("HeroesData.Parser")]
[assembly: InternalsVisibleTo("HeroesData.Parser.Tests")]

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for match award data.
    /// </summary>
    public class MatchAward : ExtractableBase<MatchAward>, IExtractable
    {
        /// <summary>
        /// Gets or sets the MVP screen image file name.
        /// </summary>
        public string? MVPScreenImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the score screen image file name.
        /// </summary>
        public string? ScoreScreenImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the award description.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the unique tag.
        /// </summary>
        public string? Tag { get; set; }

        /// <summary>
        /// Gets or sets the MVP screen image original file name.
        /// </summary>
        internal string? MVPScreenImageFileNameOriginal { get; set; }

        /// <summary>
        /// Gets or sets the score screen image original file name.
        /// </summary>
        internal string? ScoreScreenImageFileNameOriginal { get; set; }
    }
}
