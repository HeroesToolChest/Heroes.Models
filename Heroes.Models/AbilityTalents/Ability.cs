using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class Ability : AbilityTalentBase
    {
        private readonly HashSet<string> _talentIdUpgradeList = new HashSet<string>(StringComparer.Ordinal);

        public Ability() { }

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

        public static bool operator ==(Ability? ability1, Ability? ability2)
        {
            if (ability1 is null)
            {
                return ability2 is null;
            }

            return ability1.Equals(ability2);
        }

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

        public override string ToString()
        {
            if (AbilityTalentId is null)
                return $"{Tier.GetFriendlyName()}";
            else
                return $"{Tier.GetFriendlyName()} | {AbilityTalentId.Id}";
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
