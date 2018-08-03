namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipCooldown
    {
        /// <summary>
        /// Gets or sets the cooldown.
        /// </summary>
        public double? CooldownValue { get; set; }

        public override string ToString()
        {
            string text = string.Empty;
            if (CooldownValue.HasValue)
                text += $"Cooldown: {CooldownValue.Value}";

            if (string.IsNullOrEmpty(text))
                return "None";
            else
                return text;
        }
    }
}
