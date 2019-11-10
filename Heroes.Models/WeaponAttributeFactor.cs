using System;

namespace Heroes.Models
{
    /// <summary>
    /// Represents a type value pair for the attribute factor of a weapon.
    /// </summary>
    public class WeaponAttributeFactor : TypeValue
    {
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (!(obj is WeaponAttributeFactor item))
                return false;

            return Type.Equals(item.Type, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Type: {Type}, Value: {Value}";
        }
    }
}
