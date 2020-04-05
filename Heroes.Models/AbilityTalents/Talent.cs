using Heroes.Models.Extensions;
using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the information for talent data.
    /// </summary>
    public class Talent : AbilityTalentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        public Talent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        /// <param name="talentBase">A <see cref="AbilityTalentBase"/> object.</param>
        public Talent(AbilityTalentBase talentBase)
        {
            if (talentBase is null)
                throw new ArgumentNullException(nameof(talentBase));

            Name = talentBase.Name;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
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
        /// Gets a unqiue collection of prerequisite talent ids.
        /// </summary>
        public HashSet<string> PrerequisiteTalentIds { get; } = new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Determines if both objects are equal.
        /// </summary>
        /// <param name="talent1">The object to the left hand side of the operator.</param>
        /// <param name="talent2">The object to the right hand side of the operator.</param>
        /// <returns>The value indicating the result of the comparison.</returns>
        public static bool operator ==(Talent? talent1, Talent? talent2)
        {
            if (talent1 is null)
            {
                return talent2 is null;
            }

            return talent1.Equals(talent2);
        }

        /// <summary>
        /// Determines if both objects are not equal.
        /// </summary>
        /// <param name="talent1">The object to the left hand side of the operator.</param>
        /// <param name="talent2">The object to the right hand side of the operator.</param>
        /// <returns>The value indicating the result of the comparison.</returns>
        public static bool operator !=(Talent? talent1, Talent? talent2)
        {
            if (talent1 is null)
            {
                return !(talent2 is null);
            }

            return !talent1.Equals(talent2);
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
