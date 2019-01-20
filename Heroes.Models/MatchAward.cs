namespace Heroes.Models
{
    public class MatchAward : INameable
    {
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the MVP screen image file name.
        /// </summary>
        public string MVPScreenImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the MVP screen image original file name.
        /// </summary>
        public string MVPScreenImageFileNameOriginal { get; set; }

        /// <summary>
        /// Gets or sets the score screen image file name.
        /// </summary>
        public string ScoreScreenImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the score screen image original file name.
        /// </summary>
        public string ScoreScreenImageFileNameOriginal { get; set; }

        /// <summary>
        /// Gets or sets the award description.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or set the unique tag.
        /// </summary>
        public string Tag { get; set; }
    }
}
