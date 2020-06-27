using Heroes.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the information for talent data.
    /// </summary>
    public class Talent : AbilityTalentBase, IEquatable<Talent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        public Talent()
        {
        }

        /// <summary>
        /// Gets or sets the tier of the talent.
        /// </summary>
        public TalentTiers Tier { get; set; }

        /// <summary>
        /// Gets or sets the column number, also known as the sort index number.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets a unique collection of ability and talent ids that the talent affects or upgrades.
        /// </summary>
        public HashSet<string> AbilityTalentLinkIds { get; } = new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Gets a unique collection of prerequisite talent ids.
        /// </summary>
        public HashSet<string> PrerequisiteTalentIds { get; } = new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator ==(Talent? left, Talent? right)
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
        public static bool operator !=(Talent? left, Talent? right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (AbilityTalentId is null)
                return $"{Tier.GetFriendlyName()}";
            else
                return $"{Tier.GetFriendlyName()} | {AbilityTalentId.Id}";
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is null)
                return false;

            if (!(obj is Talent talent))
                return false;
            else
                return Equals(talent);
        }

        /// <inheritdoc/>
        public bool Equals([AllowNull] Talent other)
        {
            if (other is null)
                return false;

            return other.AbilityTalentId.Id.Equals(AbilityTalentId.Id, StringComparison.OrdinalIgnoreCase) && other.Tier == Tier;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Tier, Column);
        }
    }
}
