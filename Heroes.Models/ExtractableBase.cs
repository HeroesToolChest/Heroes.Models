using System;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models
{
    /// <summary>
    /// Base class that provides basic information for extractable game data.
    /// </summary>
    /// <typeparam name="T">A type of <see cref="IExtractable"/>.</typeparam>
    public abstract class ExtractableBase<T> : IEquatable<ExtractableBase<T>>
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

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator ==(ExtractableBase<T>? left, ExtractableBase<T>? right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are not equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is not equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator !=(ExtractableBase<T>? left, ExtractableBase<T>? right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is null)
                return false;

            if (obj is not ExtractableBase<T> extractableBase)
                return false;
            else
                return Equals(extractableBase);
        }

        /// <inheritdoc/>
        public bool Equals([AllowNull] ExtractableBase<T> other)
        {
            if (other is null)
                return false;

            return other.Id.Equals(Id, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id.ToUpperInvariant());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
