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
        /// Gets a unique collection of the hero play styles.
        /// </summary>
        public HashSet<string> HeroDescriptors { get; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the Life properties.
        /// </summary>
        public UnitLife Life { get; set; } = new UnitLife();

        /// <summary>
        /// Gets or sets the Energy properties.
        /// </summary>
        public UnitEnergy Energy { get; set; } = new UnitEnergy();

        /// <summary>
        /// Gets or sets the Shield properties.
        /// </summary>
        public UnitShield Shield { get; set; } = new UnitShield();

        /// <summary>
        /// Gets a collection unit armor.
        /// </summary>
        public HashSet<UnitArmor> Armor { get; } = new HashSet<UnitArmor>();

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
        /// Gets a unique collection of basic attack weapons.
        /// </summary>
        public HashSet<UnitWeapon> Weapons { get; } = new HashSet<UnitWeapon>();

        /// <summary>
        /// Gets a unique collection of attributes.
        /// </summary>
        public HashSet<string> Attributes { get; } = new HashSet<string>();

        /// <summary>
        /// Gets a unique collection of additional units associated with this unit.
        /// </summary>
        public HashSet<string> UnitIds { get; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the parent link of this unit.
        /// </summary>
        public string? ParentLink { get; set; }

        /// <summary>
        /// Gets or sets the damage type of this unit.
        /// </summary>
        public string? DamageType { get; set; }

        /// <summary>
        /// Gets a value indicating whether this unit is unique to a map.
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
            return Abilities.Where(x => x.ParentLink == null);
        }

        /// <summary>
        /// Returns a collection of all the primary abilities in the selected tier (no parent linked abilities).
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IEnumerable<Ability> PrimaryAbilities(AbilityTiers tier)
        {
            return Abilities.Where(x => x.Tier == tier && x.ParentLink == null);
        }

        /// <summary>
        /// Returns a collection of all the sub abilities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ability> SubAbilities()
        {
            return Abilities.Where(x => x.ParentLink != null);
        }

        /// <summary>
        /// Returns a collection of all the sub abilities in the selected tier.
        /// </summary>
        /// <param name="tier">The ability tier.</param>
        /// <returns></returns>
        public IEnumerable<Ability> SubAbilities(AbilityTiers tier)
        {
            return Abilities.Where(x => x.Tier == tier && x.ParentLink != null);
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
            return Weapons.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink)!;
        }

        /// <summary>
        /// Adds an <see cref="Ability"/>. Returns a value indicating the result.
        /// </summary>
        /// <param name="ability">An <see cref="Ability"/>.</param>
        /// <returns>Value indicating adding was successful.</returns>
        public bool AddAbility(Ability ability)
        {
            if (ability is null)
                throw new ArgumentNullException(nameof(ability));

            if (ability.AbilityTalentId == null)
                throw new NullReferenceException(nameof(ability.AbilityTalentId));

            return _abilitiesByAbilityTalentId.TryAdd(ability.AbilityTalentId, ability);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="ability">An <see cref="Ability"/>.</param>
        /// <returns>Value indicating the <paramref name="ability"/> exists.</returns>
        public bool ContainsAbility(Ability ability)
        {
            if (ability is null)
                throw new ArgumentNullException(nameof(ability));

            if (ability.AbilityTalentId == null)
                throw new NullReferenceException(nameof(ability.AbilityTalentId));

            return _abilitiesByAbilityTalentId.ContainsKey(ability.AbilityTalentId);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="abilityTalentId">An <see cref="AbilityTalentId"/>.</param>
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
        /// <param name="ability">An <see cref="Ability"/>.</param>
        /// <returns>Value indicating <paramref name="ability"/> was removed.</returns>
        public bool RemoveAbility(Ability ability)
        {
            if (ability is null)
                throw new ArgumentNullException(nameof(ability));

            if (ability.AbilityTalentId == null)
                throw new NullReferenceException(nameof(ability.AbilityTalentId));

            return _abilitiesByAbilityTalentId.Remove(ability.AbilityTalentId);
        }

        /// <summary>
        /// Gets the ability from the <paramref name="abilityTalentId"/>.
        /// </summary>
        /// <param name="abilityTalentId">An <see cref="AbilityTalentId"/>.</param>
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
        /// <param name="abilityTalentId">The <see cref="AbilityTalentId"/> to look for.</param>
        /// <param name="ability">The <see cref="Ability"/> that is found.</param>
        /// <returns>Returns true if the <see cref="Ability"/> is found.</returns>
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
        /// <param name="referenceId">The reference id value to look for.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>Returns a collection of <see cref="Ability"/>.</returns>
        public IEnumerable<Ability> GetAbilitiesFromReferenceId(string referenceId, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(referenceId))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(referenceId));
            }

            return _abilitiesByAbilityTalentId.Where(x => x.Key.ReferenceId.Equals(referenceId, comparisonType)).Select(x => x.Value);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return CUnitId;
        }
    }
}
