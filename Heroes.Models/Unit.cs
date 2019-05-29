using System.Collections.Generic;
using System.Linq;
using Heroes.Models.AbilityTalents;

namespace Heroes.Models
{
    public class Unit : ExtractableBase<Unit>, IExtractable
    {
        private readonly HashSet<string> HeroDescriptorsList = new HashSet<string>();
        private readonly HashSet<UnitWeapon> UnitWeaponList = new HashSet<UnitWeapon>();
        private readonly HashSet<UnitArmor> UnitArmorList = new HashSet<UnitArmor>();
        private readonly HashSet<string> AttributeList = new HashSet<string>();
        private readonly HashSet<string> UnitList = new HashSet<string>();

        private readonly Dictionary<string, Ability> AbilitiesById = new Dictionary<string, Ability>();

        /// <summary>
        /// Gets or sets the id of CUnit element stored in blizzard xml file.
        /// </summary>
        public string CUnitId { get; set; }

        /// <summary>
        /// Gets or sets the description of the unit.
        /// </summary>
        public TooltipDescription Description { get; set; }

        /// <summary>
        /// Gets a collection of the hero play styles.
        /// </summary>
        public IEnumerable<string> HeroDescriptors => HeroDescriptorsList;

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

        /// <summary>
        /// Gets or sets the gender of the hero.
        /// </summary>
        public HeroGender? Gender { get; set; }

        /// <summary>
        /// Gets a collection of abilities.
        /// </summary>
        public IEnumerable<Ability> Abilities => AbilitiesById.Values;

        /// <summary>
        /// Gets a collection of ability ids.
        /// </summary>
        public IEnumerable<string> AbilityIds => AbilitiesById.Keys;

        /// <summary>
        /// Gets a collection of basic attack weapons.
        /// </summary>
        public IEnumerable<UnitWeapon> Weapons => UnitWeaponList;

        /// <summary>
        /// Gets a collection of attributes.
        /// </summary>
        public IEnumerable<string> Attributes => AttributeList;

        /// <summary>
        /// Gets a collection of additional units associated with this hero.
        /// </summary>
        public IEnumerable<string> Units => UnitList;

        /// <summary>
        /// Gets or sets the parent link of this unit.
        /// </summary>
        public string ParentLink { get; set; }

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
        public IEnumerable<Ability> PrimaryAbilities(AbilityTier tier)
        {
            return Abilities?.Where(x => x.Tier == tier && string.IsNullOrEmpty(x.ParentLink)).ToList();
        }

        /// <summary>
        /// Returns a collection of all the sub abilities in the selected tier..
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IEnumerable<Ability> SubAbilities(AbilityTier tier)
        {
            return Abilities?.Where(x => x.Tier == tier && !string.IsNullOrEmpty(x.ParentLink)).ToList();
        }

        /// <summary>
        /// Returns a lookup of all the parent linked abilities.
        /// </summary>
        /// <returns></returns>
        public ILookup<string, Ability> ParentLinkedAbilities()
        {
           return Abilities?.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink);
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
        /// Adds a descriptor value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddHeroDescriptor(string value)
        {
            HeroDescriptorsList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsHeroDescriptor(string value)
        {
            return HeroDescriptorsList.Contains(value);
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
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsUnitWeapon(UnitWeapon unitWeapon)
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
        public bool ContainsUnitArmor(UnitArmor unitArmor)
        {
            return UnitArmorList.Contains(unitArmor);
        }

        /// <summary>
        /// Adds an attribute value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddAttribute(string value)
        {
            AttributeList.Add(value);
        }

        /// <summary>
        /// Adds a range of attribute values. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddRangeAttribute(IEnumerable<string> values)
        {
            foreach (string item in values)
            {
                AttributeList.Add(item);
            }
        }

        /// <summary>
        /// Removes an attribute value.
        /// </summary>
        /// <param name="value"></param>
        public void RemoveAttribute(string value)
        {
            AttributeList.Remove(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsAttribute(string value)
        {
            return AttributeList.Contains(value);
        }

        /// <summary>
        /// Adds an <see cref="Ability"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="ability"></param>
        public void AddAbility(Ability ability)
        {
            AbilitiesById[ability.ReferenceNameId] = ability;
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsAbility(string abilityId)
        {
            return AbilitiesById.ContainsKey(abilityId);
        }

        /// <summary>
        /// Try to get the ability from the specified ability id.
        /// </summary>
        /// <param name="abilityId"></param>
        /// <param name="ability"></param>
        /// <returns></returns>
        public bool TryGetAbility(string abilityId, out Ability ability)
        {
            return AbilitiesById.TryGetValue(abilityId, out ability);
        }

        /// <summary>
        /// Returns an ability from the ability id.
        /// </summary>
        /// <param name="abilityId"></param>
        /// <returns></returns>
        public Ability GetAbility(string abilityId)
        {
            if (string.IsNullOrEmpty(abilityId))
                return null;

            if (AbilitiesById.TryGetValue(abilityId, out Ability ability))
                return ability;
            else
                return null;
        }

        /// <summary>
        /// Adds a value. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddUnit(string value)
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
    }
}
