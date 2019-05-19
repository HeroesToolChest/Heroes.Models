using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    public class Hero : Unit
    {
        private readonly string NoPickName = "No Pick";
        private readonly string NoPickTalentIconFileName = "storm_ui_ingame_leader_talent_unselected.png";
        private readonly string UnknownTalentIconFileName = "storm_ui_icon_monk_trait1.png";

        /// <summary>
        /// Gets or sets the id of CHero element stored in blizzard xml file.
        /// </summary>
        public string CHeroId { get; set; }

        /// <summary>
        /// Gets or sets the four character code.
        /// </summary>
        public string AttributeId { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the hero.
        /// </summary>
        public string Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the mount link id.
        /// </summary>
        public string MountLinkId { get; set; }

        /// <summary>
        /// Gets or sets the hearth link id.
        /// </summary>
        public string HearthLinkId { get; set; }

        /// <summary>
        /// Gets or sets the franchise the hero belongs to.
        /// </summary>
        public HeroFranchise Franchise { get; set; }

        /// <summary>
        /// Gets or sets the hero portraits.
        /// </summary>
        public HeroPortrait HeroPortrait { get; set; } = new HeroPortrait();

        /// <summary>
        /// Gets or sets the date the hero was release.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the gender of the hero.
        /// </summary>
        public HeroGender? Gender { get; set; }

        /// <summary>
        /// Gets or sets the rarity of the hero.
        /// </summary>
        public Rarity? Rarity { get; set; }

        /// <summary>
        /// Gets or sets the ratings of the hero.
        /// </summary>
        public HeroRatings Ratings { get; set; } = new HeroRatings();

        /// <summary>
        /// Gets or sets the talents.
        /// </summary>
        public Dictionary<string, Talent> Talents { get; set; } = new Dictionary<string, Talent>();

        /// <summary>
        /// Gets or sets the roles of the hero, multiclass will be first if hero has multiple roles.
        /// </summary>
        public IList<string> Roles { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the expanded role of the hero.
        /// </summary>
        public string ExpandedRole { get; set; }

        /// <summary>
        /// Gets or sets the information text.
        /// </summary>
        public string InfoText { get; set; }

        /// <summary>
        /// Gets or sets the hero title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the search text. Space delimited.
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Gets or sets the unit type: Melee or ranged.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the additional hero units associated with this hero.
        /// </summary>
        public IList<Unit> HeroUnits { get; set; } = new List<Unit>();

        /// <summary>
        /// Returns a talent object.
        /// </summary>
        /// <param name="referenceNameId">Reference name of the talent.</param>
        /// <returns></returns>
        public Talent GetTalent(string referenceNameId)
        {
            if (Talents == null)
                return null;

            if (string.IsNullOrEmpty(referenceNameId))
            {
                // no pick
                return new Talent()
                {
                    Name = NoPickName,
                    IconFileName = NoPickTalentIconFileName,
                };
            }

            if (Talents.TryGetValue(referenceNameId, out Talent talent))
            {
                return talent;
            }
            else
            {
                return new Talent()
                {
                    Name = referenceNameId,
                    IconFileName = UnknownTalentIconFileName,
                };
            }
        }

        /// <summary>
        /// Returns a collection of all the talents in the selected tier.
        /// </summary>
        /// <param name="tier"> The talent tier.</param>
        /// <returns></returns>
        public IList<Talent> TierTalents(TalentTier tier)
        {
            return Talents.Values.Where(x => x.Tier == tier).ToList();
        }
    }
}
