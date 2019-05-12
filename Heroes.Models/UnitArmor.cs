namespace Heroes.Models
{
    public class UnitArmor
    {
        /// <summary>
        /// Gets or sets the physical (basic) armor.
        /// </summary>
        public int BasicArmor { get; set; }

        /// <summary>
        /// Gets or sets the Spell (ability) armor.
        /// </summary>
        public int AbilityArmor { get; set; }

        /// <summary>
        /// Gets or sets the Splash armor.
        /// </summary>
        public int SplashArmor { get; set; }
    }
}
