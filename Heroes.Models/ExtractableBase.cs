using System;

namespace Heroes.Models
{
    /// <summary>
    /// Base class that provides basic information for extractable game data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ExtractableBase<T>
        where T : IExtractable
    {
        /// <summary>
        /// Gets or sets the unique id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hyperlink id.
        /// </summary>
        public string HyperlinkId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the real in game name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (!(obj is T item))
                return false;

            return Id.Equals(item.Id, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 13;
        }
    }
}
