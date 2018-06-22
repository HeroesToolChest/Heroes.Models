﻿using Heroes.Models.AbilityTalents;
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
        public HeroDifficulty Difficulty { get; set; }

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
        /// Gets or sets the armor of the hero.
        /// </summary>
        public HeroArmor HeroArmor { get; set; }

        /// <summary>
        /// Gets or sets the talents.
        /// </summary>
        public Dictionary<string, Talent> Talents { get; set; }

        /// <summary>
        /// Gets or sets the roles of the hero, multiclass will be first if hero has multiple roles.
        /// </summary>
        public IList<HeroRole> Roles { get; set; } = new List<HeroRole>();

        /// <summary>
        /// Gets or sets the additional hero units associated with this hero.
        /// </summary>
        public IList<Unit> HeroUnits { get; set; } = new List<Unit>();

        /*/// <summary>
        /// Returns an ability object given the reference name.
        /// </summary>
        /// <param name="referenceName">Reference name of the ability.</param>
        /// <returns></returns>
        public Ability GetAbility(string referenceName)
        {
            if (string.IsNullOrEmpty(referenceName))
            {
                return null;
            }

            if (Abilities.TryGetValue(referenceName, out Ability ability))
            {
                return ability;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a talent object given the reference name.
        /// </summary>
        /// <param name="referenceName">Reference name of the talent.</param>
        /// <returns></returns>
        public Talent GetTalent(string referenceName)
        {
            if (string.IsNullOrEmpty(referenceName))
            {
                return Talents[string.Empty]; // no pick
            }

            if (Talents.TryGetValue(referenceName, out Talent talent))
            {
                return talent;
            }
            else
            {
                talent = Talents["NotFound"];
                talent.Name = referenceName;
                return talent;
            }
        }
        */

        /// <summary>
        /// Returns a collection of all the talents in the selected tier.
        /// </summary>
        /// <param name = "tier" > The talent tier.</param>
        /// <returns></returns>
        public ICollection<Talent> TierTalents(TalentTier tier)
        {
            return Talents.Values.Where(x => x.Tier == tier).ToList();
        }
    }
}
