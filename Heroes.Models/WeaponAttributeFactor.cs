using System;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models
{
    /// <summary>
    /// Represents a type value pair for the attribute factor of a weapon.
    /// </summary>
    public class WeaponAttributeFactor : TypeValue, IEquatable<WeaponAttributeFactor>
    {
        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator ==(WeaponAttributeFactor? left, WeaponAttributeFactor? right)
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
        public static bool operator !=(WeaponAttributeFactor? left, WeaponAttributeFactor? right)
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

            if (obj is not WeaponAttributeFactor weaponAttributeFactor)
                return false;
            else
                return Equals(weaponAttributeFactor);
        }

        /// <inheritdoc/>
        public bool Equals([AllowNull] WeaponAttributeFactor other)
        {
            if (other is null)
                return false;

            return other.Type.Equals(Type, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Type.ToUpperInvariant());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Type: {Type}, Value: {Value}";
        }
    }
}
