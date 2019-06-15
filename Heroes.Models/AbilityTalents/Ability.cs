using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class Ability : AbilityTalentBase
    {
        private readonly HashSet<string> TalentIdUpgradeList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public Ability() { }

        public Ability(AbilityTalentBase talentBase)
        {
            Name = talentBase.Name;
            ReferenceId = talentBase.ReferenceId;
            ButtonId = talentBase.ButtonId;
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
        public IEnumerable<string> TalentIdUpgrades => TalentIdUpgradeList;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ParentLink))
                return $"{Tier.GetFriendlyName()} | {ReferenceId} | {ButtonId}";
            else
                return $"{Tier.GetFriendlyName()} | {ReferenceId} | {ButtonId} -> sub-ability to {ParentLink}";
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

            TalentIdUpgradeList.Add(value);
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

            return TalentIdUpgradeList.Contains(value);
        }
    }
}
