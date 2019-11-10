using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for unit data.
    /// </summary>
    public class Unit : ExtractableBase<Unit>, IExtractable, IMapSpecific
    {
        private readonly HashSet<string> _heroDescriptorsList = new HashSet<string>();
        private readonly HashSet<UnitWeapon> _unitWeaponList = new HashSet<UnitWeapon>();
        private readonly HashSet<UnitArmor> _unitArmorList = new HashSet<UnitArmor>();
        private readonly HashSet<string> _attributeList = new HashSet<string>();
        private readonly HashSet<string> _unitIdList = new HashSet<string>();

        private readonly Dictionary<AbilityTalentId, Ability> _abilitiesByAbilityTalentId = new Dictionary<AbilityTalentId, Ability>();

        /// <summary>
        /// Gets or sets the id of CUnit element stored in blizzard xml file.
        /// </summary>
        public string CUnitId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the unit.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets a collection of the hero play styles.
        /// </summary>
        public IEnumerable<string> HeroDescriptors => _heroDescriptorsList;

        /// <summary>
        /// Gets the amount of hero play styles.
        /// </summary>
        public int HeroDescriptorsCount => _heroDescriptorsList.Count;

        /// <summary>
        /// Gets the Life properties.
        /// </summary>
        public UnitLife Life { get; set; } = new UnitLife();

        /// <summary>
        /// Gets the Energy properties.
        /// </summary>
        public UnitEnergy Energy { get; set; } = new UnitEnergy();

        /// <summary>
        /// Gets the Shield properties.
        /// </summary>
        public UnitShield Shield { get; set; } = new UnitShield();

        /// <summary>
        /// Gets a collection unit armor.
        /// </summary>
        public IEnumerable<UnitArmor> Armor => _unitArmorList;

        /// <summary>
        /// Gets the amount of unit armors.
        /// </summary>
        public int ArmorCount => _unitArmorList.Count;

        /// <summary>
        /// Gets or sets the size of the radius.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the size of the inner radius.
        /// </summary>
        public double InnerRadius { get; set; }

        /// <summary>
        /// Gets or sets the value of the speed.
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Gets or sets the distance of the sight.
        /// </summary>
        public double Sight { get; set; }

        /// <summary>
        /// Gets or sets the gender of the hero.
        /// </summary>
        public UnitGender? Gender { get; set; }

        /// <summary>
        /// Gets a collection of abilities.
        /// </summary>
        public IEnumerable<Ability> Abilities => _abilitiesByAbilityTalentId.Values;

        /// <summary>
        /// Gets the amount of abilities.
        /// </summary>
        public int AbilitiesCount => _abilitiesByAbilityTalentId.Count;

        /// <summary>
        /// Gets a collection of basic attack weapons.
        /// </summary>
        public IEnumerable<UnitWeapon> Weapons => _unitWeaponList;

        /// <summary>
        /// Gets the amount of weapons.
        /// </summary>
        public int WeaponsCount => _unitWeaponList.Count;

        /// <summary>
        /// Gets a collection of attributes.
        /// </summary>
        public IEnumerable<string> Attributes => _attributeList;

        /// <summary>
        /// Gets the amount of attributes.
        /// </summary>
        public int AttributesCount => _attributeList.Count;

        /// <summary>
        /// Gets a collection of additional units associated with this unit.
        /// </summary>
        public IEnumerable<string> UnitIds => _unitIdList;

        /// <summary>
        /// Gets the amount of units.
        /// </summary>
        public int UnitIdsCount => _unitIdList.Count;

        /// <summary>
        /// Gets or sets the parent link of this unit.
        /// </summary>
        public string? ParentLink { get; set; }

        /// <summary>
        /// Gets or sets the damage type of this unit.
        /// </summary>
        public string? DamageType { get; set; }

        /// <summary>
        /// Gets whether this unit is unique to a map.
        /// </summary>
        public bool IsMapUnique => !string.IsNullOrEmpty(MapName);

        /// <summary>
        /// Gets or sets the map name that is associated with this unit.
        /// </summary>
        public string? MapName { get; set; }

        /// <summary>
        /// Gets or sets the scaling behavior link.
        /// </summary>
        public string? ScalingBehaviorLink { get; set; }

        /// <summary>
        /// Gets or sets the kill xp.
        /// </summary>
        public int KillXP { get; set; }

        /// <summary>
        /// Gets or sets the unit portraits.
        /// </summary>
        public UnitPortrait UnitPortrait { get; set; } = new UnitPortrait();

        /// <summary>
        /// Returns a collection of all the primary abilities (no parent linked abilities).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ability> PrimaryAbilities()
        {
            return Abilities.Where(x => x.ParentLink == null).ToList();
        }

        /// <summary>
        /// Returns a collection of all the primary abilities in the selected tier (no parent linked abilities).
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IEnumerable<Ability> PrimaryAbilities(AbilityTier tier)
        {
            return Abilities.Where(x => x.Tier == tier && x.ParentLink == null).ToList();
        }

        /// <summary>
        /// Returns a collection of all the sub abilities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ability> SubAbilities()
        {
            return Abilities.Where(x => x.ParentLink != null).ToList();
        }

        /// <summary>
        /// Returns a collection of all the sub abilities in the selected tier.
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IEnumerable<Ability> SubAbilities(AbilityTier tier)
        {
            return Abilities.Where(x => x.Tier == tier && x.ParentLink != null).ToList();
        }

        /// <summary>
        /// Returns a lookup of all the parent linked abilities.
        /// </summary>
        /// <returns></returns>
        public ILookup<AbilityTalentId, Ability> ParentLinkedAbilities()
        {
            return Abilities.Where(x => x.ParentLink != null).ToLookup(x => x.ParentLink)!;
        }

        /// <summary>
        /// Returns a lookup of all the parent linked weapons.
        /// </summary>
        /// <returns></returns>
        public ILookup<string, UnitWeapon> ParentLinkedWeapons()
        {
            return _unitWeaponList.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink)!;
        }

        /// <summary>
        /// Adds a descriptor value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddHeroDescriptor(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _heroDescriptorsList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value indicating the values exists.</returns>
        public bool ContainsHeroDescriptor(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return _heroDescriptorsList.Contains(value);
        }

        /// <summary>
        /// Adds a <see cref="UnitWeapon"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="unitWeapon"></param>
        public void AddUnitWeapon(UnitWeapon unitWeapon)
        {
            if (unitWeapon == null)
            {
                throw new ArgumentNullException(nameof(unitWeapon));
            }

            if (_unitWeaponList.Contains(unitWeapon))
                _unitWeaponList.Remove(unitWeapon);

            _unitWeaponList.Add(unitWeapon);
        }

        /// <summary>
        /// Determines whether the <see cref="UnitWeapon"/> exists.
        /// </summary>
        /// <param name="unitWeapon"></param>
        /// <returns>Value indicating the <see cref="UnitWeapon"/> was found.</returns>
        public bool ContainsUnitWeapon(UnitWeapon unitWeapon)
        {
            if (unitWeapon == null)
            {
                throw new ArgumentNullException(nameof(unitWeapon));
            }

            return _unitWeaponList.Contains(unitWeapon);
        }

        /// <summary>
        /// Removes the <see cref="UnitWeapon"/>.
        /// </summary>
        /// <param name="unitWeapon"></param>
        /// <returns>Value indicating removal was successful.</returns>
        public bool RemoveUnitWeapon(UnitWeapon unitWeapon)
        {
            return _unitWeaponList.Remove(unitWeapon);
        }

        /// <summary>
        /// Adds a <see cref="UnitArmor"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="unitArmor"></param>
        public void AddUnitArmor(UnitArmor unitArmor)
        {
            if (unitArmor == null)
            {
                throw new ArgumentNullException(nameof(unitArmor));
            }

            if (_unitArmorList.Contains(unitArmor))
                _unitArmorList.Remove(unitArmor);

            _unitArmorList.Add(unitArmor);
        }

        /// <summary>
        /// Determines whether the <see cref="UnitArmor"/> exists.
        /// </summary>
        /// <param name="unitArmor"></param>
        /// <returns>Value indicating <see cref="UnitArmor"/> exists.</returns>
        public bool ContainsUnitArmor(UnitArmor unitArmor)
        {
            if (unitArmor == null)
            {
                throw new ArgumentNullException(nameof(unitArmor));
            }

            return _unitArmorList.Contains(unitArmor);
        }

        /// <summary>
        /// Adds an attribute value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddAttribute(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _attributeList.Add(value);
        }

        /// <summary>
        /// Adds a range of attribute values. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="values"></param>
        public void AddRangeAttribute(IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (string item in values)
            {
                _attributeList.Add(item);
            }
        }

        /// <summary>
        /// Removes an attribute value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value indicating the removal was successful.</returns>
        public bool RemoveAttribute(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return _attributeList.Remove(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value indicating the value exists.</returns>
        public bool ContainsAttribute(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return _attributeList.Contains(value);
        }

        /// <summary>
        /// Adds an <see cref="Ability"/>. Returns a value indicating the result.
        /// </summary>
        /// <param name="ability"></param>
        /// <returns>Value indicating adding was successful.</returns>
        public bool AddAbility(Ability ability)
        {
            if (ability.AbilityTalentId == null)
            {
                throw new NullReferenceException(nameof(ability.AbilityTalentId));
            }

            return _abilitiesByAbilityTalentId.TryAdd(ability.AbilityTalentId, ability);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="ability"></param>
        /// <returns>Value indicating the <paramref name="ability"/> exists.</returns>
        public bool ContainsAbility(Ability ability)
        {
            if (ability.AbilityTalentId == null)
            {
                throw new NullReferenceException(nameof(ability.AbilityTalentId));
            }

            return _abilitiesByAbilityTalentId.ContainsKey(ability.AbilityTalentId);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="abilityTalentId"></param>
        /// <returns>Value indicating <paramref name="abilityTalentId"/> exists.</returns>
        public bool ContainsAbility(AbilityTalentId abilityTalentId)
        {
            if (abilityTalentId == null)
            {
                throw new ArgumentNullException(nameof(abilityTalentId));
            }

            return _abilitiesByAbilityTalentId.ContainsKey(abilityTalentId);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="referenceId">The reference id of the <see cref="AbilityTalentId"/>.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>Value indicating <paramref name="referenceId"/> exists.</returns>
        public bool ContainsAbility(string referenceId, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(referenceId))
            {
                throw new ArgumentException("Argument cannot be null or emtpy.", nameof(referenceId));
            }

            return _abilitiesByAbilityTalentId.Any(x => x.Key.ReferenceId.Equals(referenceId, comparisonType));
        }

        /// <summary>
        /// Removes an <see cref="Ability"/>.
        /// </summary>
        /// <param name="ability"></param>
        /// <returns>Value indicating <paramref name="ability"/> was removed.</returns>
        public bool RemoveAbility(Ability ability)
        {
            if (ability.AbilityTalentId == null)
            {
                throw new NullReferenceException(nameof(ability.AbilityTalentId));
            }

            return _abilitiesByAbilityTalentId.Remove(ability.AbilityTalentId);
        }

        /// <summary>
        /// Gets the ability from the <paramref name="abilityTalentId"/>.
        /// </summary>
        /// <param name="abilityTalentId"></param>
        /// <returns></returns>
        public Ability GetAbility(AbilityTalentId abilityTalentId)
        {
            if (abilityTalentId == null)
            {
                throw new ArgumentNullException(nameof(abilityTalentId));
            }

            return _abilitiesByAbilityTalentId[abilityTalentId];
        }

        /// <summary>
        /// Looks for an ability from the given <paramref name="abilityTalentId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="abilityTalentId"></param>
        /// <param name="ability"></param>
        /// <returns></returns>
        public bool TryGetAbility(AbilityTalentId abilityTalentId, [NotNullWhen(true)] out Ability? ability)
        {
            if (abilityTalentId == null)
            {
                throw new ArgumentNullException(nameof(abilityTalentId));
            }

            return _abilitiesByAbilityTalentId.TryGetValue(abilityTalentId, out ability);
        }

        /// <summary>
        /// Returns a collection of abilities from an <see cref="AbilityTalentId.ReferenceId"/>.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns></returns>
        public IEnumerable<Ability> GetAbilities(string referenceId, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(referenceId))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(referenceId));
            }

            return _abilitiesByAbilityTalentId.Where(x => x.Key.ReferenceId.Equals(referenceId, comparisonType)).Select(x => x.Value);
        }

        /// <summary>
        /// Adds a value. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddUnitId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _unitIdList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value indicating the <paramref name="value"/> exists.</returns>
        public bool ContainsUnitId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return _unitIdList.Contains(value);
        }

        /// <summary>
        /// Removes a value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value indicating the <paramref name="value"/> was removed.</returns>
        public bool RemoveUnitId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return _unitIdList.Remove(value);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return CUnitId;
        }
    }
}
