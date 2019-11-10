namespace Heroes.Models.AbilityTalents.Tooltip
{
    /// <summary>
    /// Contains the information releated to cooldown tooltip.
    /// </summary>
    public class TooltipCooldown
    {
        /// <summary>
        /// Gets or sets the cooldown text.
        /// </summary>
        public TooltipDescription? CooldownTooltip { get; set; }

        /// <summary>
        /// Gets or sets the toggle cooldown.
        /// </summary>
        public double? ToggleCooldown { get; set; }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return CooldownTooltip?.RawDescription;
        }
    }
}
