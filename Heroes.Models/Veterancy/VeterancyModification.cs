using System.Collections.Generic;

namespace Heroes.Models.Veterancy
{
    /// <summary>
    /// Contains the informatino related to the modications for veterancies.
    /// </summary>
    public class VeterancyModification
    {
        /// <summary>
        /// Gets or sets the kill xp bonus.
        /// </summary>
        public double KillXpBonus { get; set; }

        /// <summary>
        /// Gets or sets the collection of vital max modifications.
        /// </summary>
        public ICollection<VeterancyVitalMax> VitalMaxCollection { get; set; } = new List<VeterancyVitalMax>();

        /// <summary>
        /// Gets or sets the collection of vital max fraction modifications.
        /// </summary>
        public ICollection<VeterancyVitalMaxFraction> VitalMaxFractionCollection { get; set; } = new List<VeterancyVitalMaxFraction>();

        /// <summary>
        /// Gets or sets the collection of vital regen modifications.
        /// </summary>
        public ICollection<VeterancyVitalRegen> VitalRegenCollection { get; set; } = new List<VeterancyVitalRegen>();

        /// <summary>
        /// Gets or sets the collection of vital regen fraction modifications.
        /// </summary>
        public ICollection<VeterancyVitalRegenFraction> VitalRegenFractionCollection { get; set; } = new List<VeterancyVitalRegenFraction>();

        /// <summary>
        /// Gets or sets the collection of damage dealt scaled modifications.
        /// </summary>
        public ICollection<VeterancyDamageDealtScaled> DamageDealtScaledCollection { get; set; } = new List<VeterancyDamageDealtScaled>();

        /// <summary>
        /// Gets or sets the collection of damage dealt fraction modifications.
        /// </summary>
        public ICollection<VeterancyDamageDealtFraction> DamageDealtFractionCollection { get; set; } = new List<VeterancyDamageDealtFraction>();
    }
}
