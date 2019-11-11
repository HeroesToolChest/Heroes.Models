using Heroes.Models.Veterancy;
using System.Collections.Generic;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for behavior veterancy data.
    /// </summary>
    public class BehaviorVeterancy : ExtractableBase<BehaviorVeterancy>, IExtractable, IMapSpecific
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

        /// <summary>
        /// Gets whether this veterancy is unique to a map.
        /// </summary>
        public bool IsMapUnique => !string.IsNullOrEmpty(MapName);

        /// <summary>
        /// Gets or sets the map name that is associated with this veterancy.
        /// </summary>
        public string? MapName { get; set; }
    }
}
