namespace Heroes.Models
{
    public class TextureSheet
    {
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Get or sets the number of rows in the texture sheet.
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Gets or sets the number of column in the texture sheet.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Gets or sets the amount of frames.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the duration per frame.
        /// </summary>
        public int DurationPerFrame { get; set; }
    }
}
