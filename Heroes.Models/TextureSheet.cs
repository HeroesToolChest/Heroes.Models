namespace Heroes.Models
{
    /// <summary>
    /// Contains the properties for a texture sheet.
    /// </summary>
    public class TextureSheet
    {
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number of rows in the texture sheet.
        /// </summary>
        public int? Rows { get; set; }

        /// <summary>
        /// Gets or sets the number of column in the texture sheet.
        /// </summary>
        public int? Columns { get; set; }
    }
}
