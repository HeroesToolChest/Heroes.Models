namespace Heroes.Models
{
    public class WeaponAttributeFactor
    {
        /// <summary>
        /// Gets or sets the type (Minion, Structure, etc...)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the bonus factor.
        /// </summary>
        public double Value { get; set; }
    }
}
