using System;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models;

/// <summary>
/// Contains the information related to unit armor.
/// </summary>
public class UnitArmor : IEquatable<UnitArmor>
{
    /// <summary>
    /// Gets or sets the type of armor (Hero, Merc, etc...)
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the physical (basic) armor.
    /// </summary>
    public int BasicArmor { get; set; }

    /// <summary>
    /// Gets or sets the Spell (ability) armor.
    /// </summary>
    public int AbilityArmor { get; set; }

    /// <summary>
    /// Gets or sets the Splash armor.
    /// </summary>
    public int SplashArmor { get; set; }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator ==(UnitArmor? left, UnitArmor? right)
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
    public static bool operator !=(UnitArmor? left, UnitArmor? right)
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

        if (obj is not UnitArmor unitArmor)
            return false;
        else
            return Equals(unitArmor);
    }

    /// <inheritdoc/>
    public bool Equals([AllowNull] UnitArmor other)
    {
        if (other is null)
            return false;

        return other.Type.Equals(Type, StringComparison.OrdinalIgnoreCase);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Type.ToUpperInvariant());
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{nameof(Type)}: {Type}, Basic: {BasicArmor}, Ability: {AbilityArmor}, Splash: {SplashArmor}";
    }
}
