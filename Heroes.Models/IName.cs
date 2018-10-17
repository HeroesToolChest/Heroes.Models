namespace Heroes.Models
{
    public interface IName
    {
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        string Name { get; set; }
    }
}
