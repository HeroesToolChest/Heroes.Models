namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipEnergy
    {
        /// <summary>
        /// Gets or sets the energy text.
        /// </summary>
        public TooltipDescription EnergyTooltip { get; set; }

        /// <summary>
        /// Gets or sets the energy value.
        /// </summary>
        public double EnergyValue { get; set; }

        public override string ToString()
        {
            return EnergyTooltip.RawDescription;
        }
    }
}
