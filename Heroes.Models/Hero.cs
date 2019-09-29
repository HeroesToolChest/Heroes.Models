using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Heroes.Models
{
    public class Hero : Unit
    {
        private readonly string _noPickName = "No Pick";
        private readonly string _noPickTalentIconFileName = "storm_ui_ingame_leader_talent_unselected.png";
        private readonly string _unknownTalentIconFileName = "storm_ui_icon_monk_trait1.png";

        private readonly HashSet<string> _roleList = new HashSet<string>();
        private readonly Dictionary<string, Talent> _talentsById = new Dictionary<string, Talent>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<Hero> _heroUnitList = new HashSet<Hero>();

        /// <summary>
        /// Gets or sets the id of CHero element stored in blizzard xml file.
        /// </summary>
        public string CHeroId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the four character code.
        /// </summary>
        public string AttributeId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the difficulty of the hero.
        /// </summary>
        public string Difficulty { get; set; } = string.Empty;

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
        public IEnumerable<Talent> Talents => _talentsById.Values;

        /// <summary>
        /// Gets the amount of talents.
        /// </summary>
        public int TalentsCount => _talentsById.Values.Count;

        /// <summary>
        /// Gets a collection of talent ids.
        /// </summary>
        public IEnumerable<string> TalentIds => _talentsById.Keys;

        /// <summary>
        /// Gets the amount of talent ids.
        /// </summary>
        public int TalentIdsCount => _talentsById.Keys.Count;

        /// <summary>
        /// Gets a collection roles of the hero, multiclass will be first if hero has multiple roles.
        /// </summary>
        public IEnumerable<string> Roles => _roleList;

        /// <summary>
        /// Gets the amount of roles.
        /// </summary>
        public int RolesCount => _roleList.Count;

        /// <summary>
        /// Gets or sets the expanded role of the hero.
        /// </summary>
        public string ExpandedRole { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the information text.
        /// </summary>
        public string InfoText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hero title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the search text. Space delimited.
        /// </summary>
        public string SearchText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unit type: Melee or ranged.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets a collection of <see cref="Hero"/> objects.
        /// </summary>
        public IEnumerable<Hero> HeroUnits => _heroUnitList;

        /// <summary>
        /// Gets the amount of <see cref="Hero"/> objects.
        /// </summary>
        public int HeroUnitCount => _heroUnitList.Count;

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
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _roleList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsRole(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return _roleList.Contains(value);
        }

        /// <summary>
        /// Adds an <see cref="Talent"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="talent"></param>
        public void AddTalent(Talent talent)
        {
            if (talent.AbilityTalentId is null)
                throw new ArgumentException($"{nameof(talent.AbilityTalentId)} cannot be null", nameof(talent));

            _talentsById[talent.AbilityTalentId.ReferenceId] = talent;
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="talentId">The reference id of the talent.</param>
        /// <returns></returns>
        public bool ContainsTalent(string talentId)
        {
            if (talentId == null)
            {
                throw new ArgumentNullException(nameof(talentId));
            }

            return _talentsById.ContainsKey(talentId);
        }

        /// <summary>
        /// Try to get the talent from the specified talent id.
        /// </summary>
        /// <param name="talentId">The reference id of the talent.</param>
        /// <param name="talent"></param>
        /// <returns></returns>
        public bool TryGetTalent(string talentId, [NotNullWhen(true)] out Talent? talent)
        {
            return _talentsById.TryGetValue(talentId, out talent);
        }

        /// <summary>
        /// Returns a talent from the talent id.
        /// </summary>
        /// <param name="talentId">The reference id of the talent.</param>
        /// <returns></returns>
        public Talent GetTalent(string talentId)
        {
            if (string.IsNullOrWhiteSpace(talentId))
            {
                // no pick
                return new Talent()
                {
                    Name = _noPickName,
                    IconFileName = _noPickTalentIconFileName,
                };
            }

            if (_talentsById.TryGetValue(talentId, out Talent? talent))
            {
                return talent;
            }
            else
            {
                return new Talent()
                {
                    Name = talentId,
                    IconFileName = _unknownTalentIconFileName,
                };
            }
        }

        /// <summary>
        /// Adds a <see cref="Hero"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="hero"></param>
        public void AddHeroUnit(Hero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException(nameof(hero));
            }

            _heroUnitList.Add(hero);
        }

        public override string ToString()
        {
            return CHeroId;
        }
    }
}
