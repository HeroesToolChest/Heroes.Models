using System;

namespace Heroes.Models
{
    public class WeaponAttributeFactor
    {
        /// <summary>
        /// Gets or sets the type (Minion, Structure, etc...)
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of the bonus factor.
        /// </summary>
        public double Value { get; set; }

        public override bool Equals(object? obj)
        {
            if (!(obj is WeaponAttributeFactor item))
                return false;

            return Type.Equals(item.Type, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public override string ToString()
        {
            return $"Type: {Type}, Value: {Value}";
        }
    }
}
