namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipEnergy
    {
        /// <summary>
        /// Gets or sets the energy text.
        /// </summary>
        public TooltipDescription EnergyText { get; set; }

        /// <summary>
        /// Gets or sets the type of energy.
        /// </summary>
        public UnitEnergyType EnergyType { get; set; } = UnitEnergyType.None;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(EnergyText?.RawDescription))
                return string.Empty;
            else
                return $"Energy: {EnergyText.RawDescription} - Type: {EnergyType}";
        }
    }
}
