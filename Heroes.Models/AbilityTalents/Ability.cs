using Heroes.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the information for ability data.
    /// </summary>
    public class Ability : AbilityTalentBase, IEquatable<Ability>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class.
        /// </summary>
        public Ability()
        {
            IsActive = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class.
        /// </summary>
        /// <param name="talentBase">An <see cref="AbilityTalentBase"/> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="talentBase"/> is <see langword="null"/>.</exception>
        public Ability(AbilityTalentBase talentBase)
        {
            if (talentBase is null)
                throw new ArgumentNullException(nameof(talentBase));

            Name = talentBase.Name;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
        }

        /// <summary>
        /// Gets or sets the tier of the ability.
        /// </summary>
        public AbilityTiers Tier { get; set; }

        /// <summary>
        /// Gets a unique collection of talent ids that are associated with the ability.
        /// </summary>
        public HashSet<string> TalentIdUpgrades { get; } = new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator ==(Ability? left, Ability? right)
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
        public static bool operator !=(Ability? left, Ability? right)
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

            if (!(obj is Ability ability))
                return false;
            else
                return Equals(ability);
        }

        /// <inheritdoc/>
        public bool Equals([AllowNull] Ability other)
        {
            if (other is null)
                return false;

            return other.AbilityTalentId.Id.Equals(AbilityTalentId.Id, StringComparison.OrdinalIgnoreCase) && other.Tier == Tier;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Tier);
        }
    }
}
