using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the information for ability data.
    /// </summary>
    public class Ability : AbilityTalentBase
    {
        private readonly HashSet<string> _talentIdUpgradeList = new HashSet<string>(StringComparer.Ordinal);

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
        /// <param name="talentBase"></param>
        public Ability(AbilityTalentBase talentBase)
        {
            Name = talentBase.Name;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
        }

        /// <summary>
        /// Gets or sets the tier of the ability.
        /// </summary>
        public AbilityTier Tier { get; set; }

        /// <summary>
        /// Gets a collection of talent ids that are associated with the ability.
        /// </summary>
        public IEnumerable<string> TalentIdUpgrades => _talentIdUpgradeList;

        /// <summary>
        /// Determines if both objects are equal.
        /// </summary>
        /// <param name="ability1"></param>
        /// <param name="ability2"></param>
        /// <returns></returns>
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
        /// <param name="ability1"></param>
        /// <param name="ability2"></param>
        /// <returns></returns>
        public static bool operator !=(Ability? ability1, Ability? ability2)
        {
            if (ability1 is null)
            {
                return !(ability2 is null);
            }

            return !ability1.Equals(ability2);
        }

        /// <summary>
        /// Adds a talent id upgrade value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddTalentIdUpgrade(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(value));
            }

            _talentIdUpgradeList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsTalentIdUpgrade(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(value));
            }

            return _talentIdUpgradeList.Contains(value);
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
            return base.GetHashCode();
        }
    }
}
