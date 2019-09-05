namespace Heroes.Models
{
    public class MatchAward : ExtractableBase<MatchAward>, IExtractable
    {
        /// <summary>
        /// Gets or sets the MVP screen image file name.
        /// </summary>
        public string MVPScreenImageFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the MVP screen image original file name.
        /// </summary>
        public string MVPScreenImageFileNameOriginal { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the score screen image file name.
        /// </summary>
        public string ScoreScreenImageFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the score screen image original file name.
        /// </summary>
        public string ScoreScreenImageFileNameOriginal { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the award description.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or set the unique tag.
        /// </summary>
        public string Tag { get; set; } = string.Empty;
    }
}
