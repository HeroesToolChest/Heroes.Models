using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class Talent : AbilityTalentBase
    {
        public Talent() { }

        public Talent(AbilityTalentBase talentBase)
        {
            Name = talentBase.Name;
            ReferenceNameId = talentBase.ReferenceNameId;
            FullTooltipNameId = talentBase.FullTooltipNameId;
            ShortTooltipNameId = talentBase.ShortTooltipNameId;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
        }

        /// <summary>
        /// Gets or sets the tier of the talent.
        /// </summary>
        public TalentTier Tier { get; set; }

        /// <summary>
        /// Gets or sets the column number, also known as the sort index number.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the ability and talents that the talent affects or upgrades.
        /// </summary>
        public IEnumerable<string> AbilityTalentLinkId { get; set; }

        public override string ToString() => $"{Tier.GetFriendlyName()} | {ReferenceNameId}";
    }
}
