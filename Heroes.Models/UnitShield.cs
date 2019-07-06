namespace Heroes.Models
{
    public class UnitShield
    {
        /// <summary>
        /// Gets or sets the max number of shields the unit has.
        /// </summary>
        public double ShieldMax { get; set; }

        /// <summary>
        /// Gets or sets the shield scaling.
        /// </summary>
        public double ShieldScaling { get; set; }

        /// <summary>
        /// Gets or sets the shield regeneration delay.
        /// </summary>
        public double ShieldRegenerationDelay { get; set; }

        /// <summary>
        /// Gets or sets the shiled regneration rate.
        /// </summary>
        public double ShieldRegenerationRate { get; set; }

        /// <summary>
        /// Gets or sets the shield regeneration rate scaling.
        /// </summary>
        public double ShieldRegnerationRateScaling { get; set; }

        public string ShieldType { get; set; }

        public override string ToString()
        {
            return $"Life: {ShieldMax} (+{ShieldScaling * 100}% per level) - RegenRate: {ShieldRegenerationRate} (+{ShieldRegnerationRateScaling * 100}% per level)";
        }
    }
}
