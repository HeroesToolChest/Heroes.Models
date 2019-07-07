using System.Collections.Generic;

namespace Heroes.Models.Veterancy
{
    public class BehaviorVeterancy
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public bool CombineModifications { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public bool CombineXP { get; set; }

        /// <summary>
        /// Gets or sets the collection of veterancy levels.
        /// </summary>
        public ICollection<VeterancyLevel> VeterancyLevels { get; set; } = new List<VeterancyLevel>();
    }
}
