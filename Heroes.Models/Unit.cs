using Heroes.Models.AbilityTalents;

namespace Heroes.Models;

/// <summary>
/// Contains the information for unit data.
/// </summary>
public class Unit : ExtractableBase<Unit>, IExtractable, IMapSpecific
{
    private readonly Dictionary<AbilityTalentId, Ability> _abilitiesByAbilityTalentId = new();

    /// <summary>
    /// Gets or sets the id of CUnit element stored in blizzard xml file.
    /// </summary>
    public string CUnitId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the unit.
    /// </summary>
    public TooltipDescription? Description { get; set; }

    /// <summary>
    /// Gets or sets the info text of the unit.
    /// </summary>
    public TooltipDescription? InfoText { get; set; }

    /// <summary>
    /// Gets a unique collection of the hero play styles.
    /// </summary>
    public HashSet<string> HeroDescriptors { get; } = new();

    /// <summary>
    /// Gets or sets the Life properties.
    /// </summary>
    public UnitLife Life { get; set; } = new();

    /// <summary>
    /// Gets or sets the Energy properties.
    /// </summary>
    public UnitEnergy Energy { get; set; } = new();

    /// <summary>
    /// Gets or sets the Shield properties.
    /// </summary>
    public UnitShield Shield { get; set; } = new();

    /// <summary>
    /// Gets a collection unit armor.
    /// </summary>
    public HashSet<UnitArmor> Armor { get; } = new();

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
    public HashSet<UnitWeapon> Weapons { get; } = new();

    /// <summary>
    /// Gets a unique collection of attributes.
    /// </summary>
    public HashSet<string> Attributes { get; } = new();

    /// <summary>
    /// Gets a unique collection of additional units associated with this unit.
    /// </summary>
    public HashSet<string> UnitIds { get; } = new();

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
    public int? KillXP { get; set; }

    /// <summary>
    /// Gets or sets the unit portraits.
    /// </summary>
    public UnitPortrait UnitPortrait { get; set; } = new();

    /// <summary>
    /// Returns a collection of all the primary abilities (no parent linked abilities).
    /// </summary>
    /// <returns>A collection of abilities.</returns>
    public IEnumerable<Ability> PrimaryAbilities()
    {
        return Abilities.Where(x => x.ParentLink == null);
    }

    /// <summary>
    /// Returns a collection of all the primary abilities in the selected tier (no parent linked abilities).
    /// </summary>
    /// <param name="tier">The ability tier.</param>
    /// <returns>A collection of abilities.</returns>
    public IEnumerable<Ability> PrimaryAbilities(AbilityTiers tier)
    {
        return Abilities.Where(x => x.Tier == tier && x.ParentLink == null);
    }

    /// <summary>
    /// Returns a collection of all the sub abilities.
    /// </summary>
    /// <returns>A collection of abilities.</returns>
    public IEnumerable<Ability> SubAbilities()
    {
        return Abilities.Where(x => x.ParentLink != null);
    }

    /// <summary>
    /// Returns a collection of all the sub abilities in the selected tier.
    /// </summary>
    /// <param name="tier">The ability tier.</param>
    /// <returns>A collection of abilities.</returns>
    public IEnumerable<Ability> SubAbilities(AbilityTiers tier)
    {
        return Abilities.Where(x => x.Tier == tier && x.ParentLink != null);
    }

    /// <summary>
    /// Returns a lookup of all the parent linked abilities.
    /// </summary>
    /// <returns>A lookup of the parent linked abilities.</returns>
    public ILookup<AbilityTalentId, Ability> ParentLinkedAbilities()
    {
        return Abilities.Where(x => x.ParentLink != null).ToLookup(x => x.ParentLink)!;
    }

    /// <summary>
    /// Returns a lookup of all the parent linked weapons.
    /// </summary>
    /// <returns>A lookup of the parent linked weapons.</returns>
    public ILookup<string, UnitWeapon> ParentLinkedWeapons()
    {
        return Weapons.Where(x => !string.IsNullOrEmpty(x.ParentLink)).ToLookup(x => x.ParentLink)!;
    }

    /// <summary>
    /// Adds an <see cref="Ability"/>. Returns a value indicating the result.
    /// </summary>
    /// <param name="ability">An <see cref="Ability"/>.</param>
    /// <returns><see langword="true"/> if the value was added; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ability"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <paramref name="ability"/> <see cref="AbilityTalentId"/> is <see langword="null"/>.</exception>
    public bool AddAbility(Ability ability)
    {
        ArgumentNullException.ThrowIfNull(ability, nameof(ability));

        if (ability.AbilityTalentId == null)
            throw new ArgumentException(nameof(ability.AbilityTalentId));

        return _abilitiesByAbilityTalentId.TryAdd(ability.AbilityTalentId, ability);
    }

    /// <summary>
    /// Determines whether the value exists.
    /// </summary>
    /// <param name="ability">An <see cref="Ability"/>.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ability"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <paramref name="ability"/> <see cref="AbilityTalentId"/> is <see langword="null"/>.</exception>
    public bool ContainsAbility(Ability ability)
    {
        ArgumentNullException.ThrowIfNull(ability, nameof(ability));

        if (ability.AbilityTalentId == null)
            throw new ArgumentException(nameof(ability.AbilityTalentId));

        return _abilitiesByAbilityTalentId.ContainsKey(ability.AbilityTalentId);
    }

    /// <summary>
    /// Determines whether the value exists.
    /// </summary>
    /// <param name="abilityTalentId">An <see cref="AbilityTalentId"/>.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="abilityTalentId"/> is <see langword="null"/>.</exception>
    public bool ContainsAbility(AbilityTalentId abilityTalentId)
    {
        ArgumentNullException.ThrowIfNull(abilityTalentId, nameof(abilityTalentId));

        return _abilitiesByAbilityTalentId.ContainsKey(abilityTalentId);
    }

    /// <summary>
    /// Determines whether the value exists.
    /// </summary>
    /// <param name="referenceId">The reference id of the <see cref="AbilityTalentId"/>.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="referenceId"/> is null or empty.</exception>
    public bool ContainsAbility(string referenceId, StringComparison comparisonType)
    {
        if (string.IsNullOrWhiteSpace(referenceId))
            throw new ArgumentException($"'{nameof(referenceId)}' cannot be null or whitespace.", nameof(referenceId));

        return _abilitiesByAbilityTalentId.Any(x => x.Key.ReferenceId.Equals(referenceId, comparisonType));
    }

    /// <summary>
    /// Removes an <see cref="Ability"/>.
    /// </summary>
    /// <param name="ability">An <see cref="Ability"/>.</param>
    /// <returns><see langword="true"/> if the value was removed; otherwise <see langword="false"/>.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="ability"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <paramref name="ability"/> <see cref="AbilityTalentId"/> is <see langword="null"/>.</exception>
    public bool RemoveAbility(Ability ability)
    {
        ArgumentNullException.ThrowIfNull(ability, nameof(ability));

        if (ability.AbilityTalentId == null)
            throw new InvalidOperationException($"{nameof(ability.AbilityTalentId)} cannot be null");

        return _abilitiesByAbilityTalentId.Remove(ability.AbilityTalentId);
    }

    /// <summary>
    /// Gets the ability from the <paramref name="abilityTalentId"/>.
    /// </summary>
    /// <param name="abilityTalentId">An <see cref="AbilityTalentId"/>.</param>
    /// <returns>An <see cref="Ability"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="abilityTalentId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="abilityTalentId"/> was not found.</exception>
    public Ability GetAbility(AbilityTalentId abilityTalentId)
    {
        ArgumentNullException.ThrowIfNull(abilityTalentId, nameof(abilityTalentId));

        return _abilitiesByAbilityTalentId[abilityTalentId];
    }

    /// <summary>
    /// Looks for an ability from the given <paramref name="abilityTalentId"/>, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="abilityTalentId">The <see cref="AbilityTalentId"/> to look for.</param>
    /// <param name="ability">The <see cref="Ability"/> that is found.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="abilityTalentId"/> is <see langword="null"/>.</exception>
    public bool TryGetAbility(AbilityTalentId abilityTalentId, [NotNullWhen(true)] out Ability? ability)
    {
        ArgumentNullException.ThrowIfNull(abilityTalentId, nameof(abilityTalentId));

        return _abilitiesByAbilityTalentId.TryGetValue(abilityTalentId, out ability);
    }

    /// <summary>
    /// Returns a collection of abilities from an <see cref="AbilityTalentId.ReferenceId"/>.
    /// </summary>
    /// <param name="referenceId">The reference id value to look for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>A collection of <see cref="Ability"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="referenceId"/> is null or empty.</exception>
    public IEnumerable<Ability> GetAbilitiesFromReferenceId(string referenceId, StringComparison comparisonType)
    {
        if (string.IsNullOrWhiteSpace(referenceId))
            throw new ArgumentException($"'{nameof(referenceId)}' cannot be null or whitespace.", nameof(referenceId));

        return _abilitiesByAbilityTalentId.Where(x => x.Key.ReferenceId.Equals(referenceId, comparisonType)).Select(x => x.Value);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return CUnitId;
    }
}
