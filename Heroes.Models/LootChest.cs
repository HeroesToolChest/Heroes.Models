namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for loot chest data.
    /// </summary>
    public class LootChest : ExtractableBase<LootChest>, IExtractable
    {
        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the maximum numbers of re-rolls for this loot chest.
        /// </summary>
        public int MaxRerolls { get; set; }

        /// <summary>
        /// Gets or sets the type description id.
        /// </summary>
        public string? TypeDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the event name associated with this loot chest.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public Rarity Rarity { get; set; } = Rarity.Common;
    }
}
