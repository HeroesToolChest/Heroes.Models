namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for emoticon image.
    /// </summary>
    public class EmoticonImage
    {
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the index of the image in the texture sheet.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the amount of frames.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the duration per frame.
        /// </summary>
        public int? DurationPerFrame { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{FileName}, {nameof(Index)}: {Index}, {nameof(Width)}: {Width}";
        }
    }
}
