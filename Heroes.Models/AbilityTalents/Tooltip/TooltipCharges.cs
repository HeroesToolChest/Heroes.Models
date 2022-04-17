﻿namespace Heroes.Models.AbilityTalents.Tooltip;

/// <summary>
/// Contains the information related to the charges.
/// </summary>
public class TooltipCharges
{
    /// <summary>
    /// Gets or sets the maximum amount of charges, null if no charges available.
    /// </summary>
    public int? CountMax { get; set; }

    /// <summary>
    /// Gets or sets the starting amount of charges, null if no charges available.
    /// </summary>
    public int? CountStart { get; set; }

    /// <summary>
    /// Gets or sets the amount of charges consumed on use.
    /// </summary>
    public int? CountUse { get; set; }

    /// <summary>
    /// Gets or sets the cooldown between charge casts.
    /// </summary>
    public double? RecastCooldown { get; set; }

    /// <summary>
    /// Gets or sets if charges are hidden.
    /// </summary>
    public bool? IsHideCount { get; set; }

    /// <summary>
    /// Gets a value indicating whether charges exists.
    /// </summary>
    public bool HasCharges => CountMax.HasValue || (CountMax.HasValue && CountMax.Value > 0);

    /// <inheritdoc/>
    public override string ToString()
    {
        if (HasCharges)
            return $"Max Charges: {CountMax} - Start: {CountStart} - Use: {CountUse} - Hidden: {IsHideCount}";
        else
            return "No charges";
    }
}
