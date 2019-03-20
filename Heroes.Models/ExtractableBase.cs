namespace Heroes.Models
{
    public class ExtractableBase<T>
        where T : IExtractable
    {
        /// <summary>
        /// Gets or sets the unique id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink id.
        /// </summary>
        public string HyperlinkId { get; set; }

        /// <summary>
        /// Gets or sets the real in game name.
        /// </summary>
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Id == ((T)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 13;
        }
    }
}
