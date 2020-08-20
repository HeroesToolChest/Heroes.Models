namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for reward portrait data.
    /// </summary>
    public class RewardPortrait : RewardBase, IExtractable
    {
        /// <summary>
        /// Gets or sets the texture sheet associated with the portrait.
        /// </summary>
        public TextureSheet TextureSheet { get; set; } = new TextureSheet();

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string? CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; } = Rarity.Common;

        /// <summary>
        /// Gets or sets the portrait pack id associated with the reward portrait.
        /// </summary>
        public string? PortraitPackId { get; set; }

        /// <summary>
        /// Gets or sets the icon slot number.
        /// </summary>
        public int IconSlot { get; set; }

        /// <summary>
        /// Gets or sets the hero id associated with the reward portrait.
        /// </summary>
        public string? HeroId { get; set; }
    }
}
