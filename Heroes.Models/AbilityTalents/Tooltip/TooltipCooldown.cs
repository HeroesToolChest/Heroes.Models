namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipCooldown
    {
        /// <summary>
        /// Gets or sets the cooldown text.
        /// </summary>
        public TooltipDescription CooldownText { get; set; }

        /// <summary>
        /// Gets or sets the toggle cooldown.
        /// </summary>
        public double? ToggleCooldown { get; set; }

        public override string ToString()
        {
            return CooldownText.RawDescription;
        }
    }
}
