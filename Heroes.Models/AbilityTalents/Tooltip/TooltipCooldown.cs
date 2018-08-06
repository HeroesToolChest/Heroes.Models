namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipCooldown
    {
        /// <summary>
        /// Gets or sets the cooldown text.
        /// </summary>
        public string CooldownText { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(CooldownText))
                return string.Empty;
            else
                return $"Cooldown: {CooldownText}";
        }
    }
}
