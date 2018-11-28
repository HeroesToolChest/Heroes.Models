using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class Ability : AbilityTalentBase
    {
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
        /// Gets or sets the talent ids that are associated with the ability.
        /// </summary>
        public ICollection<string> TalentIdUpgrades { get; set; } = new List<string>();

        public override string ToString() => $"{Tier.GetFriendlyName()} | {ReferenceNameId}";
    }
}
