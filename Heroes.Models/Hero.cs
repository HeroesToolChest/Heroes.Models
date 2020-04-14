using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for hero data.
    /// </summary>
    public class Hero : Unit
    {
        private readonly string _noPickName = "No Pick";
        private readonly string _noPickTalentIconFileName = "storm_ui_ingame_leader_talent_unselected.png";
        private readonly string _unknownTalentIconFileName = "storm_ui_icon_monk_trait1.png";

        private readonly Dictionary<string, Talent> _talentsById = new Dictionary<string, Talent>(StringComparer.Ordinal);

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
        public Rarity Rarity { get; set; } = Rarity.Common;

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
        /// Gets a unique collection roles of the hero, multiclass will be first if hero has multiple roles.
        /// </summary>
        public HashSet<string> Roles { get; } = new HashSet<string>(StringComparer.Ordinal);

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
        /// Gets a unique collection of <see cref="Hero"/> objects.
        /// </summary>
        public HashSet<Hero> HeroUnits { get; } = new HashSet<Hero>();

        /// <summary>
        /// Returns a collection of all the talents in the selected tier.
        /// </summary>
        /// <param name="tier"> The talent tier.</param>
        /// <returns></returns>
        public IEnumerable<Talent> TierTalents(TalentTiers tier)
        {
            return Talents.Where(x => x.Tier == tier);
        }

        /// <summary>
        /// Adds an <see cref="Talent"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="talent">A <see cref="Talent"/> object.</param>
        public void AddTalent(Talent talent)
        {
            if (talent is null)
                throw new ArgumentNullException(nameof(talent));

            if (talent.AbilityTalentId is null)
                throw new ArgumentException($"{nameof(talent.AbilityTalentId)} cannot be null", nameof(talent));

            _talentsById[talent.AbilityTalentId.ReferenceId] = talent;
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="talentId">The reference id of the talent.</param>
        /// <returns>Value indicating the <paramref name="talentId"/> exists.</returns>
        public bool ContainsTalent(string talentId)
        {
            if (talentId == null)
            {
                throw new ArgumentNullException(nameof(talentId));
            }

            return _talentsById.ContainsKey(talentId);
        }

        /// <summary>
        /// Looks for a talent with the given <paramref name="talentId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="talentId">The reference id of the talent.</param>
        /// <param name="talent">The <see cref="Talent"/> object of the <paramref name="talentId"/>.</param>
        /// <returns>Returns true if the <see cref="Talent"/> exists.</returns>
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

        /// <inheritdoc/>
        public override string ToString()
        {
            return CHeroId;
        }
    }
}
