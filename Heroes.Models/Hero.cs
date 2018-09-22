using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    public class Hero : Unit
    {
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
        public HeroRarity? Rarity { get; set; }

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
        /// Gets or sets the additional hero units associated with this hero.
        /// </summary>
        public IList<Unit> HeroUnits { get; set; } = new List<Unit>();

        /// <summary>
        /// Returns an ability object.
        /// </summary>
        /// <param name="referenceNameId">Reference name of the ability.</param>
        /// <returns></returns>
        public Ability GetAbility(string referenceNameId)
        {
            if (string.IsNullOrEmpty(referenceNameId))
                return null;

            if (Abilities.TryGetValue(referenceNameId, out Ability ability))
                return ability;
            else
                return null;
        }

        /// <summary>
        /// Returns a talent object.
        /// </summary>
        /// <param name="referenceNameId">Reference name of the talent.</param>
        /// <returns></returns>
        public Talent GetTalent(string referenceNameId)
        {
            if (string.IsNullOrEmpty(referenceNameId))
                return Talents[TalentType.NoPick.ToString()]; // no pick

            if (Talents.TryGetValue(referenceNameId, out Talent talent))
            {
                return talent;
            }
            else
            {
                talent = Talents[TalentType.NotFound.ToString()];
                talent.Name = referenceNameId;
                return talent;
            }
        }

        /// <summary>
        /// Returns a collection of all the talents in the selected tier.
        /// </summary>
        /// <param name="tier"> The talent tier.</param>
        /// <returns></returns>
        public ICollection<Talent> TierTalents(TalentTier tier)
        {
            return Talents.Values.Where(x => x.Tier == tier).ToList();
        }
    }
}
