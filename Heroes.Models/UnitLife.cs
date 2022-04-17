﻿namespace Heroes.Models;

/// <summary>
/// Contains information related to unit life.
/// </summary>
public class UnitLife
{
    /// <summary>
    /// Gets or sets the amount of life the unit has.
    /// </summary>
    public double LifeMax { get; set; }

    /// <summary>
    /// Gets or sets the life regeneration rate of the unit.
    /// </summary>
    public double LifeRegenerationRate { get; set; }

    /// <summary>
    /// Gets or sets the life scaling.
    /// </summary>
    public double LifeScaling { get; set; }

    /// <summary>
    /// Gets or sets the life regeneration rate scaling.
    /// </summary>
    public double LifeRegenerationRateScaling { get; set; }

    /// <summary>
    /// Gets or sets the life type.
    /// </summary>
    public string? LifeType { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Life: {LifeMax} (+{LifeScaling * 100}% per level) - RegenRate: {LifeRegenerationRate} (+{LifeRegenerationRateScaling * 100}% per level)";
    }
}
