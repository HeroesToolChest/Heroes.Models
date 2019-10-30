namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipEnergy
    {
        /// <summary>
        /// Gets or sets the energy text.
        /// </summary>
        public TooltipDescription? EnergyTooltip { get; set; }

        /// <summary>
        /// Gets or sets the energy value.
        /// </summary>
        internal double? EnergyValue { get; set; }

        public override string ToString()
        {
            return EnergyTooltip is null ? string.Empty : EnergyTooltip.RawDescription;
        }
    }
}
