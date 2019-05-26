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

        private readonly HashSet<string> RoleList = new HashSet<string>();
        private readonly HashSet<string> UnitList = new HashSet<string>();

        private readonly Dictionary<string, Talent> TalentsById = new Dictionary<string, Talent>();

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
        /// Gets a collection of talents.
        /// </summary>
        public IEnumerable<Talent> Talents => TalentsById.Values;

        /// <summary>
        /// Gets a collection of talent ids.
        /// </summary>
        public IEnumerable<string> TalentIds => TalentsById.Keys;

        /// <summary>
        /// Gets a collection roles of the hero, multiclass will be first if hero has multiple roles.
        /// </summary>
        public IEnumerable<string> Roles => RoleList;

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
        /// Gets a collection of additional units associated with this hero.
        /// </summary>
        public IEnumerable<string> Units => UnitList;

        /// <summary>
        /// Returns a collection of all the talents in the selected tier.
        /// </summary>
        /// <param name="tier"> The talent tier.</param>
        /// <returns></returns>
        public IEnumerable<Talent> TierTalents(TalentTier tier)
        {
            return Talents.Where(x => x.Tier == tier);
        }

        /// <summary>
        /// Adds a role value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddRole(string value)
        {
            RoleList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsRole(string value)
        {
            return RoleList.Contains(value);
        }

        /// <summary>
        /// Adds a value. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddHeroUnit(string value)
        {
            UnitList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsUnit(string value)
        {
            return UnitList.Contains(value);
        }

        /// <summary>
        /// Adds an <see cref="Talent"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="talent"></param>
        public void AddTalent(Talent talent)
        {
            TalentsById[talent.ReferenceNameId] = talent;
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsTalent(string talentId)
        {
            return TalentsById.ContainsKey(talentId);
        }

        /// <summary>
        /// Try to get the talent from the specified talent id.
        /// </summary>
        /// <param name="talentId"></param>
        /// <param name="talent"></param>
        /// <returns></returns>
        public bool TryGetTalent(string talentId, out Talent talent)
        {
            return TalentsById.TryGetValue(talentId, out talent);
        }

        /// <summary>
        /// Returns a talent from the talent id.
        /// </summary>
        /// <param name="talentId"></param>
        /// <returns></returns>
        public Talent GetTalent(string talentId)
        {
            if (string.IsNullOrEmpty(talentId))
            {
                // no pick
                return new Talent()
                {
                    Name = NoPickName,
                    IconFileName = NoPickTalentIconFileName,
                };
            }

            if (TalentsById.TryGetValue(talentId, out Talent talent))
            {
                return talent;
            }
            else
            {
                return new Talent()
                {
                    Name = talentId,
                    IconFileName = UnknownTalentIconFileName,
                };
            }
        }
    }
}
