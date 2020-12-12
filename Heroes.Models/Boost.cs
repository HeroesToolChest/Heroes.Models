using System;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for boost data.
    /// </summary>
    public class Boost : ExtractableBase<Boost>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the boosts.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the release date of the boost.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
    }
}
