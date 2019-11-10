namespace Heroes.Models.Veterancy
{
    /// <summary>
    /// Contains the information releated to veterancy levels.
    /// </summary>
    public class VeterancyLevel
    {
        /// <summary>
        /// Gets or sets the minimum xp for this level.
        /// </summary>
        public int MinimumVeterancyXP { get; set; }

        /// <summary>
        /// Gets or sets the veterancy modification.
        /// </summary>
        public VeterancyModification VeterancyModification { get; set; } = new VeterancyModification();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(MinimumVeterancyXP)}: {MinimumVeterancyXP}";
        }
    }
}
