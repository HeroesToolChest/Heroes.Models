using System.Collections.Generic;

namespace Heroes.Models
{
    public class UnitPortrait
    {
        /// <summary>
        /// Gets or sets the party frame file name.
        /// </summary>
        public ICollection<string> PartyFrameFileName { get; set; } = new List<string>();
    }
}
