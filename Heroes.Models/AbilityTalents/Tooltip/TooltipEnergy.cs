namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipEnergy
    {
        /// <summary>
        /// Gets or sets the energy text.
        /// </summary>
        public string EnergyText { get; set; }

        /// <summary>
        /// Gets or sets the type of energy.
        /// </summary>
        public UnitEnergyType EnergyType { get; set; } = UnitEnergyType.None;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(EnergyText))
                return string.Empty;
            else
                return $"Energy: {EnergyText} - Type: {EnergyType}";
        }
    }
}
