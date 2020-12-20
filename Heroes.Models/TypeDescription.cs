namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for type description data.
    /// </summary>
    public class TypeDescription : ExtractableBase<Boost>, IExtractable
    {
        /// <summary>
        /// Gets or sets the texture sheet associated with the type description.
        /// </summary>
        public TextureSheet TextureSheet { get; set; } = new TextureSheet();

        /// <summary>
        /// Gets or sets the index of the icon on the textsheet.
        /// </summary>
        public int IconIndex { get; set; }
    }
}
