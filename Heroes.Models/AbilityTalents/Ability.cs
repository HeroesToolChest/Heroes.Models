using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class Ability : AbilityTalentBase
    {
        private readonly HashSet<string> TalentIdUpgradeList = new HashSet<string>();

        public Ability() { }

        public Ability(AbilityTalentBase talentBase)
        {
            Name = talentBase.Name;
            ReferenceNameId = talentBase.ReferenceNameId;
            FullTooltipNameId = talentBase.FullTooltipNameId;
            ShortTooltipNameId = talentBase.ShortTooltipNameId;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
        }

        /// <summary>
        /// Gets or sets the tier of the ability.
        /// </summary>
        public AbilityTier Tier { get; set; }

        /// <summary>
        /// Gets or sets the ability parent that is associated with this ability.
        /// </summary>
        public string ParentLink { get; set; }

        /// <summary>
        /// Gets or sets the button name of the ability.
        /// Should be used for internal purposes only.
        /// </summary>
        public string ButtonName { get; set; }

        /// <summary>
        /// Gets a collectin of talent ids that are associated with the ability.
        /// </summary>
        public IEnumerable<string> TalentIdUpgrades => TalentIdUpgradeList;

        public override string ToString() => $"{Tier.GetFriendlyName()} | {ReferenceNameId}";

        /// <summary>
        /// Adds a talent id upgrade value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddTalentIdUpgrade(string value)
        {
            TalentIdUpgradeList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TalentIdUpgradeExists(string value)
        {
            return TalentIdUpgradeList.Contains(value);
        }
    }
}
