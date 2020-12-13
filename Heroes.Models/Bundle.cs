using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for bundle data.
    /// </summary>
    public class Bundle : ExtractableBase<Bundle>, IExtractable
    {
        private readonly HashSet<string> _heroSkins = new HashSet<string>();
        private readonly Dictionary<string, HashSet<string>> _heroSkinsByHeroId = new Dictionary<string, HashSet<string>>();

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
        public string? ImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this bundle.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is dynamic content.
        /// </summary>
        public bool IsDynamicContent { get; set; }

        /// <summary>
        /// Gets a unique collection of hero ids that are in this bundle.
        /// </summary>
        public HashSet<string> HeroIds { get; } = new HashSet<string>();

        /// <summary>
        /// Gets a unique collection of mount ids that are in this bundle.
        /// </summary>
        public HashSet<string> MountIds { get; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets the boost id that is in this bundle.
        /// </summary>
        public string? BoostBonusId { get; set; } = null;

        /// <summary>
        /// Gets or sets the amount of gold in this bundle.
        /// </summary>
        public int? GoldBonus { get; set; } = null;

        /// <summary>
        /// Gets or sets the amount of gems in this bundle.
        /// </summary>
        public int? GemsBonus { get; set; } = null;

        /// <summary>
        /// Gets a collection of hero skin ids.
        /// </summary>
        public IEnumerable<string> HeroSkins => _heroSkins.ToList();

        /// <summary>
        /// Gets the amount of hero skins.
        /// </summary>
        public int HeroSkinsCount => _heroSkins.Count;

        /// <summary>
        /// Gets a collection of hero ids that have a hero skin associated with it.
        /// </summary>
        public IEnumerable<string> HeroIdsWithHeroSkins => _heroSkinsByHeroId.Keys;

        /// <summary>
        /// Gets the amount of hero ids that have a hero skin associated with it.
        /// </summary>
        public int HeroIdsWithHeroSkinsCount => _heroSkinsByHeroId.Keys.Count;

        /// <summary>
        /// Adds hero skin id along with its associated hero id.
        /// </summary>
        /// <param name="heroId">The hero id.</param>
        /// <param name="heroSkinId">The skin id.</param>
        /// <exception cref="ArgumentException">The <paramref name="heroId"/> or <paramref name="heroSkinId"/> is <see langword="null"/> or empty.</exception>
        public void AddHeroSkin(string heroId, string heroSkinId)
        {
            if (string.IsNullOrEmpty(heroId))
                throw new ArgumentException($"'{nameof(heroId)}' cannot be null or empty", nameof(heroId));

            if (string.IsNullOrEmpty(heroSkinId))
                throw new ArgumentException($"'{nameof(heroSkinId)}' cannot be null or empty", nameof(heroSkinId));

            if (_heroSkinsByHeroId.TryGetValue(heroId, out HashSet<string>? heroSkinIds))
            {
                heroSkinIds.Add(heroSkinId);
            }
            else
            {
                _heroSkinsByHeroId.Add(heroId, new HashSet<string>() { heroSkinId });
            }

            _heroSkins.Add(heroSkinId);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="heroSkinId">The hero skin id.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="heroSkinId"/> is <see langword="null"/>.</exception>
        public bool ContainsHeroSkinId(string heroSkinId)
        {
            if (heroSkinId is null)
                throw new ArgumentNullException(nameof(heroSkinId));

            return _heroSkins.Contains(heroSkinId);
        }

        /// <summary>
        /// Gets a collection of hero skins ids from the <paramref name="heroId"/>.
        /// </summary>
        /// <param name="heroId">The hero id of the skins.</param>
        /// <returns>A collection of hero skins ids of the <paramref name="heroId"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="heroId"/> was not found.</exception>
        public IEnumerable<string> GetSkinIdsByHeroId(string heroId)
        {
            if (heroId is null)
                throw new ArgumentNullException(nameof(heroId));

            return _heroSkinsByHeroId[heroId].ToList();
        }

        /// <summary>
        /// Gets a collection of hero skins ids from the <paramref name="heroId"/>.
        /// </summary>
        /// <param name="heroId">The hero id of the skins.</param>
        /// <param name="heroSkinIds">A collection of hero skins ids associated with the <paramref name="heroId"/>.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is <see langword="null"/>.</exception>
        public bool TryGetSkinIdsByHeroId(string heroId, [NotNullWhen(true)] out IEnumerable<string>? heroSkinIds)
        {
            if (heroId is null)
                throw new ArgumentNullException(nameof(heroId));

            heroSkinIds = null;

            if (_heroSkinsByHeroId.TryGetValue(heroId, out HashSet<string>? values))
            {
                heroSkinIds = values.ToList();
                return true;
            }

            return false;
        }
    }
}
