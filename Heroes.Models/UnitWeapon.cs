using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models;

/// <summary>
/// Contains the information related to unit weapon.
/// </summary>
public class UnitWeapon : IEquatable<UnitWeapon>
{
    /// <summary>
    /// Gets or sets the unique id of the weapon.
    /// </summary>
    public string WeaponNameId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the weapon.
    /// </summary>
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the amount of damage the attack deals.
    /// </summary>
    public double Damage { get; set; }

    /// <summary>
    /// Gets the collection of attribute factors.
    /// </summary>
    public HashSet<WeaponAttributeFactor> AttributeFactors { get; } = new();

    /// <summary>
    /// Gets or sets the time between attacks.
    /// </summary>
    public double Period { get; set; }

    /// <summary>
    /// Gets or sets the distance of the attack.
    /// </summary>
    public double Range { get; set; }

    /// <summary>
    /// Gets or sets the damage scaling per level.
    /// </summary>
    public double DamageScaling { get; set; }

    /// <summary>
    /// Gets or sets the unit that is associated with this weapon.
    /// </summary>
    public string? ParentLink { get; set; }

    /// <summary>
    /// Gets the attacks per second.
    /// </summary>
    /// <returns>A value indicating the number of attacks per second.</returns>
    public double AttacksPerSecond
    {
        get
        {
            if (Period <= 0)
                return 0;

            return 1 / Period;
        }
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator ==(UnitWeapon? left, UnitWeapon? right)
    {
        if (left is null)
            return right is null;
        return left.Equals(right);
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are not equal.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is not equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator !=(UnitWeapon? left, UnitWeapon? right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is null)
            return false;

        if (obj is not UnitWeapon unitWeapon)
            return false;
        else
            return Equals(unitWeapon);
    }

    /// <inheritdoc/>
    public bool Equals([AllowNull] UnitWeapon other)
    {
        if (other is null)
            return false;

        return other.WeaponNameId.Equals(WeaponNameId, StringComparison.OrdinalIgnoreCase);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(WeaponNameId.ToUpperInvariant());
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return WeaponNameId;
    }
}
