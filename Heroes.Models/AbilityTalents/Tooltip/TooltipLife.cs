namespace Heroes.Models.AbilityTalents.Tooltip;

/// <summary>
/// Contains the information releated to the life tooltip.
/// </summary>
public class TooltipLife
{
    /// <summary>
    /// Gets or sets the health text.
    /// </summary>
    public TooltipDescription? LifeCostTooltip { get; set; }

    /// <summary>
    /// Gets or sets the life value.
    /// </summary>
    internal double? LifeValue { get; set; }

    /// <inheritdoc/>
    public override string? ToString()
    {
        return LifeCostTooltip?.RawDescription;
    }
}
