using System;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the neccessary properties for a unique identifier for abilites and talents.
    /// </summary>
    public class AbilityTalentId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbilityTalentId"/> class.
        /// </summary>
        /// <param name="referenceId">The ability id.</param>
        /// <param name="buttonId">The button id.</param>
        public AbilityTalentId(string referenceId, string buttonId)
        {
            ReferenceId = referenceId;
            ButtonId = buttonId;
        }

        /// <summary>
        /// Gets the unique id. Same as <see cref="ToString()"/>.
        /// <br/>
        /// Id is as follows: <see cref="ReferenceId"/>|<see cref="ButtonId"/>|<see cref="AbilityType"/>|<see cref="IsPassive"/>.
        /// </summary>
        public string Id => ToString();

        /// <summary>
        /// Gets or sets the reference id. This is usually the ability id.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the button id.
        /// </summary>
        public string ButtonId { get; set; }

        /// <summary>
        /// Gets or sets the abilityType.
        /// </summary>
        public AbilityTypes AbilityType { get; set; } = AbilityTypes.Unknown;

        /// <summary>
        /// Gets or sets a value indicating whether this is a passive ability.
        /// </summary>
        public bool IsPassive { get; set; } = false;

        /// <summary>
        /// Determines if both objects are equal.
        /// </summary>
        /// <param name="abilityTalentId1">The object to the left hand side of the operator.</param>
        /// <param name="abilityTalentId2">The object to the right hand side of the operator.</param>
        /// <returns>The value indicating the result of the comparison.</returns>
        public static bool operator ==(AbilityTalentId? abilityTalentId1, AbilityTalentId? abilityTalentId2)
        {
            if (abilityTalentId1 is null)
            {
                return abilityTalentId2 is null;
            }

            return abilityTalentId1.Equals(abilityTalentId2);
        }

        /// <summary>
        /// Determines if both objects are not equal.
        /// </summary>
        /// <param name="abilityTalentId1">The object to the left hand side of the operator.</param>
        /// <param name="abilityTalentId2">The object to the right hand side of the operator.</param>
        /// <returns>The value indicating the result of the comparison.</returns>
        public static bool operator !=(AbilityTalentId? abilityTalentId1, AbilityTalentId? abilityTalentId2)
        {
            if (abilityTalentId1 is null)
            {
                return !(abilityTalentId2 is null);
            }

            return !abilityTalentId1.Equals(abilityTalentId2);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{ReferenceId}|{ButtonId}|{AbilityType}|{IsPassive}";
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (!(obj is AbilityTalentId item))
                return false;

            return item.Id.ToUpperInvariant().Equals(Id.ToUpperInvariant(), StringComparison.Ordinal);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return ToString().ToUpperInvariant().GetHashCode(StringComparison.Ordinal);
        }
    }
}
