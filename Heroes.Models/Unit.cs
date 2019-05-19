using System.Collections.Generic;
using System.Linq;
using Heroes.Models.AbilityTalents;

namespace Heroes.Models
{
    public class Unit : ExtractableBase<Unit>, IExtractable
    {
        private readonly HashSet<UnitWeapon> UnitWeaponList = new HashSet<UnitWeapon>();
        private readonly HashSet<UnitArmor> UnitArmorList = new HashSet<UnitArmor>();

        /// <summary>
        /// Gets or sets the id of CUnit element stored in blizzard xml file.
        /// </summary>
        public string CUnitId { get; set; }

        /// <summary>
        /// Gets or sets the description of the unit.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the hero play styles.
        /// </summary>
        public ICollection<string> HeroDescriptors { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the Life properties.
        /// </summary>
        public UnitLife Life { get; set; } = new UnitLife();

        /// <summary>
        /// Gets or sets the Energy properties.
        /// </summary>
        public UnitEnergy Energy { get; set; } = new UnitEnergy();

        /// <summary>
        /// Gets a collection unit armor.
        /// </summary>
        public IEnumerable<UnitArmor> Armor => UnitArmorList;

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
        /// Gets a collection of basic attack weapons.
        /// </summary>
        public IEnumerable<UnitWeapon> Weapons => UnitWeaponList;

        /// <summary>
        /// Gets or sets a list of attributes.
        /// </summary>
        public HashSet<string> Attributes { get; set; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the damage type of this unit.
        /// </summary>
        public string DamageType { get; set; }

        /// <summary>
        /// Gets or sets the target info panel image file name.
        /// </summary>
        public string TargetInfoPanelImageFileName { get; set; }

        /// <summary>
        /// Gets whether this unit is unique to a map.
        /// </summary>
        public bool IsMapUnique => !string.IsNullOrEmpty(MapName);

        /// <summary>
        /// Gets or sets the map name that is associated with this unit.
        /// </summary>
        public string MapName { get; set; }

        /// <summary>
        /// Gets or sets the scaling behavior link.
        /// </summary>
        public string ScalingBehaviorLink { get; set; }

        /// <summary>
        /// Returns a collection of all the primary abilities in the selected tier (no parent linked abilities).
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IList<Ability> PrimaryAbilities(AbilityTier tier)
        {
            return Abilities?.Values.Where(x => x.Tier == tier && string.IsNullOrEmpty(x.ParentLink)).ToList();
        }

        /// <summary>
        /// Returns a collection of all the sub abilities in the selected tier..
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IList<Ability> SubAbilities(AbilityTier tier)
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
            return UnitWeaponList?.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink);
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Adds a <see cref="UnitWeapon"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="unitWeapon"></param>
        public void AddUnitWeapon(UnitWeapon unitWeapon)
        {
            if (UnitWeaponList.Contains(unitWeapon))
                UnitWeaponList.Remove(unitWeapon);

            UnitWeaponList.Add(unitWeapon);
        }

        /// <summary>
        /// Determines whether the <see cref="UnitWeapon"/> exists.
        /// </summary>
        /// <param name="unitWeapon"></param>
        /// <returns></returns>
        public bool UnitWeaponExists(UnitWeapon unitWeapon)
        {
            return UnitWeaponList.Contains(unitWeapon);
        }

        /// <summary>
        /// Adds a <see cref="UnitArmor"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="unitArmor"></param>
        public void AddUnitArmor(UnitArmor unitArmor)
        {
            if (UnitArmorList.Contains(unitArmor))
                UnitArmorList.Remove(unitArmor);

            UnitArmorList.Add(unitArmor);
        }

        /// <summary>
        /// Determines whether the <see cref="UnitArmor"/> exists.
        /// </summary>
        /// <param name="unitArmor"></param>
        /// <returns></returns>
        public bool UnitArmorExists(UnitArmor unitArmor)
        {
            return UnitArmorList.Contains(unitArmor);
        }
    }
}
