using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for bundle data.
    /// </summary>
    public class Bundle : ExtractableBase<Bundle>, IExtractable
    {
        /// <summary>
        /// Gets or sets the sort name used for sorting the bundles.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the release date of the bundle.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the franchise the bundle belongs to.
        /// </summary>
        public HeroFranchise? Franchise { get; set; }

        /// <summary>
        /// Gets or sets the bundle image.
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this bundle.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets a unique collection of hero ids that are in this bundle.
        /// </summary>
        public HashSet<string> HeroIds { get; } = new HashSet<string>();

        /// <summary>
        /// Gets or a unique collection of hero skin ids, along with the assoicated hero id, that are in this bundle.
        /// </summary>
        public HashSet<(string HeroId, string SkinId)> HeroSkinIds { get; } = new HashSet<(string HeroId, string SkinId)>();

        /// <summary>
        /// Gets a unique collection of mount ids that are in this bundle.
        /// </summary>
        public HashSet<string> MountIds { get; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the boost id that is in this bundle.
        /// </summary>
        public string? BoostBonusId { get; set; } = null;
    }
}
