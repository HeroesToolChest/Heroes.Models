using Heroes.Models.Extensions;
using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the information for ability data.
    /// </summary>
    public class Ability : AbilityTalentBase
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
        /// Determines if both objects are equal.
        /// </summary>
        /// <param name="ability1">The object to the left hand side of the operator.</param>
        /// <param name="ability2">The object to the right hand side of the operator.</param>
        /// <returns>The value indicating the result of the comparison.</returns>
        public static bool operator ==(Ability? ability1, Ability? ability2)
        {
            if (ability1 is null)
            {
                return ability2 is null;
            }

            return ability1.Equals(ability2);
        }

        /// <summary>
        /// Determines if both objects are not equal.
        /// </summary>
        /// <param name="ability1">The object to the left hand side of the operator.</param>
        /// <param name="ability2">The object to the right hand side of the operator.</param>
        /// <returns>The value indicating the result of the comparison.</returns>
        public static bool operator !=(Ability? ability1, Ability? ability2)
        {
            if (ability1 is null)
            {
                return !(ability2 is null);
            }

            return !ability1.Equals(ability2);
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
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}
