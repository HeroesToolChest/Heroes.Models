﻿using System.Collections.Generic;
using System.Linq;
using Heroes.Models.AbilityTalents;

namespace Heroes.Models
{
    public class Unit
    {
        /// <summary>
        /// Gets or sets the id of CUnit element stored in blizzard xml file.
        /// </summary>
        public string CUnitId { get; set; }

        /// <summary>
        /// Gets or sets the real in game name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the  shorthand name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the description of the unit.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the unit type: Melee or ranged.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Life properties.
        /// </summary>
        public UnitLife Life { get; set; } = new UnitLife();

        /// <summary>
        /// Gets or sets the Energy properties.
        /// </summary>
        public UnitEnergy Energy { get; set; } = new UnitEnergy();

        /// <summary>
        /// Gets or sets the armor.
        /// </summary>
        public UnitArmor Armor { get; set; }

        public double Radius { get; set; }

        public double InnerRadius { get; set; }

        public double Speed { get; set; }

        public double Sight { get; set; }

        public Dictionary<string, Ability> Abilities { get; set; } = new Dictionary<string, Ability>();

        /// <summary>
        /// Gets or sets the parent link of this unit.
        /// </summary>
        public string ParentLink { get; set; }

        /// <summary>
        /// Gets or sets a list of basic attack weapons.
        /// </summary>
        public IList<UnitWeapon> Weapons { get; set; } = new List<UnitWeapon>();

        /// <summary>
        /// Returns a collection of all the primary abilities in the selected tier (no parent linked abilities).
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public ICollection<Ability> PrimaryAbilities(AbilityTier tier)
        {
            return Abilities?.Values.Where(x => x.Tier == tier && string.IsNullOrEmpty(x.ParentLink)).ToList();
        }

        /// <summary>
        /// Returns a collection of all the sub abilities in the selected tier..
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public ICollection<Ability> SubAbilities(AbilityTier tier)
        {
            return Abilities?.Values.Where(x => x.Tier == tier && !string.IsNullOrEmpty(x.ParentLink)).ToList();
        }

        /// <summary>
        /// Returns a lookup of all the parent linked abilities.
        /// </summary>
        /// <returns></returns>
        public ILookup<string, Ability> ParentLinkedAbilities()
        {
           return Abilities?.Values.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink);
        }

        /// <summary>
        /// Returns a lookup of all the parent linked weapons.
        /// </summary>
        /// <returns></returns>
        public ILookup<string, UnitWeapon> ParentLinkedWeapons()
        {
            return Weapons?.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
