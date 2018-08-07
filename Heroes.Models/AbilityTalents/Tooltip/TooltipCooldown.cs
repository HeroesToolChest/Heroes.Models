namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipCooldown
    {
        /// <summary>
        /// Gets or sets the cooldown text.
        /// </summary>
        public TooltipDescription CooldownText { get; set; }

        public override string ToString()
        {
            return CooldownText.RawDescription;
        }
    }
}
