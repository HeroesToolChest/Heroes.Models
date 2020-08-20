using System;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the neccessary properties for a unique identifier for abilites and talents.
    /// </summary>
    public class AbilityTalentId : IEquatable<AbilityTalentId>
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
        public bool IsPassive { get; set; }

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator ==(AbilityTalentId? left, AbilityTalentId? right)
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
        public static bool operator !=(AbilityTalentId? left, AbilityTalentId? right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{ReferenceId}|{ButtonId}|{AbilityType}|{IsPassive}";
        }

        /// <inheritdoc/>
        public bool Equals([AllowNull] AbilityTalentId other)
        {
            if (other is null)
                return false;

            return other.Id.Equals(Id, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is null)
                return false;

            if (!(obj is AbilityTalentId abilityTalentId))
                return false;
            else
                return Equals(abilityTalentId);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(ReferenceId.ToUpperInvariant(), ButtonId.ToUpperInvariant(), AbilityType, IsPassive);
        }
    }
}
