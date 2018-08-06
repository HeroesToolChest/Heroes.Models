namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipCharges
    {
        /// <summary>
        /// Gets or sets the maximum amount of charges, null if no charges available.
        /// </summary>
        public int? CountMax { get; set; } = null;

        /// <summary>
        /// Gets or sets the starting amount of charges, null if no charges available.
        /// </summary>
        public int? CountStart { get; set; } = null;

        /// <summary>
        /// Gets or sets the amount of charges consumed on use.
        /// </summary>
        public int? CountUse { get; set; } = null;

        /// <summary>
        /// Gets or sets if charges are hidden.
        /// </summary>
        public bool? IsHideCount { get; set; } = null;

        /// <summary>
        /// Returns true is charges exists.
        /// </summary>
        public bool HasCharges => CountMax.HasValue || (CountMax.HasValue && CountMax.Value > 0);

        /// <summary>
        /// Gets or sets the charge cooldown text.
        /// </summary>
        public string CooldownText { get; set; }

        public override string ToString()
        {
            if (HasCharges)
                return $"Max Charges: {CountMax} - Start: {CountStart} - Use: {CountUse} - Hidden: {IsHideCount} - {CooldownText}";
            else
                return "No charges";
        }
    }
}
